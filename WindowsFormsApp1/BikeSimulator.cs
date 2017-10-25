using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserData;

namespace Remote_Healtcare_Console
{
    class BikeSimulator : Kettler {

        private Thread BikeThread;
        private ISet<BikeData> data;
        private int count;
        private List<int> RecordedHF;
        private List<int> RecordedResistance;
        private System.Timers.Timer timer;
        private TimeSpan minusTimeSpan;
        private double VO2;

        private bool WarmingUpState, MainTestState, Steady, Secure;

        public BikeSimulator(Console console) : base(console) {
            this.console = console;
            data = console.data;
            count = 0;
            BikeThread = new Thread(Update);
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            WarmingUpState = false;
            MainTestState = false;
            Steady = false;
            RecordedHF = new List<int>();
            RecordedResistance = new List<int>();
            minusTimeSpan = new TimeSpan(0,0,0);
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Update();
        }

        public override void Reset() {
            throw new NotImplementedException();
        }

        public override void SetResistance(int power) {
            throw new NotImplementedException();
        }

        public override void SetTime(int mm, int ss) {
            throw new NotImplementedException();
        }

        public override void Update() {
            if (count < data.Count)
            {
                if (count > 0)
                {
                    if (data.ElementAt(count - 1).Time != data.ElementAt(count).Time)
                    {
                        if (data.ElementAt(count).Time.Minutes >= 2 && WarmingUpState)
                        {
                            WarmingUpState = false;
                            MainTestState = true;
                            console.SetFaseLabel("Main test");
                            minusTimeSpan += new TimeSpan(0, 2, 0);
                        }
                        else if (MainTestState && data.ElementAt(count).Time.Minutes >= 6)
                        {
                            MainTestState = false;
                            console.SetFaseLabel("Cooling down");
                            CalculateVO2MaX(console.user, (int)RecordedHF.Average(), (int)RecordedResistance.Max());
                        }

                        TimeSpan tempTime = data.ElementAt(count).Time - minusTimeSpan;

                        if (MainTestState)
                        {
                            if (data.ElementAt(count).Time.Seconds == 0 || (data.ElementAt(count).Time.Seconds % 15 == 0 && data.ElementAt(count).Time.Minutes >= 4))
                            {
                                if (RecordedHF.Count > 0)
                                {
                                    if (RecordedHF.Last() - data.ElementAt(count).Pulse > 5 || RecordedHF.Last() - data.ElementAt(count).Pulse < -5)
                                    {
                                        Steady = false;
                                    }
                                    else
                                    {
                                        Steady = true;
                                    }
                                }

                                RecordedHF.Add(data.ElementAt(count).Pulse);
                                RecordedResistance.Add(data.ElementAt(count).Resistance);
                                console.SetOldPulse(RecordedHF.Last().ToString());
                            }
                        }

                        try
                        {
                            console.Invoke((MethodInvoker)delegate
                            {
                                // Running on the UI thread
                                console.SetPulse(data.ElementAt(count).Pulse.ToString());
                                console.SetRPM(data.ElementAt(count).Rpm.ToString());
                                console.SetResistance(data.ElementAt(count).Resistance.ToString());
                                console.SetTime(tempTime.ToString());
                                console.SetSteady(Steady);
                                console.AddDataToChart(data.ElementAt(count).Rpm, data.ElementAt(count).Pulse, data.ElementAt(count).Resistance);
                                Application.DoEvents();
                            });
                        }
                        catch (System.InvalidOperationException e)
                        {
                            System.Console.WriteLine(e.StackTrace);
                        }
                        catch (System.ComponentModel.InvalidAsynchronousStateException e)
                        {
                            System.Console.WriteLine(e.StackTrace);
                        }
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                count++;
            }
            else
            {
                Stop();
            }
        }

        public override void SetDistance(int distance) {
            throw new NotImplementedException();
        }

        public override void Start() {
            //BikeThread.Start();
            WarmingUpState = true;
            timer.Start();
        }

        public override void Stop() {
            //BikeThread.Abort();
            timer.Stop();
        }

        public override void SetManual() {
            throw new NotImplementedException();
        }

        public void CalculateVO2MaX(User user, int shr, int watt)
        {
            double vo2max = 0;
            if (user.male == null || user.birthyear == null || user.weight == null)
                return;
            if ((bool)user.male)
                vo2max = (0.00212 * watt + 0.299) / (0.769 * shr - 48.5) * 100;
            else
                vo2max = (0.00193 * watt + 0.326) / (0.769 * shr - 56.1) * 100;

            int age = DateTime.Now.Year - (int)user.birthyear;
            double factor;
            if (age < 40 && age >= 35)
                factor = 0.87;
            else if (age < 45)
                factor = 0.83;
            else if (age < 50)
                factor = 0.78;
            else if (age < 55)
                factor = 0.75;
            else if (age < 60)
                factor = 0.71;
            else if (age < 65)
                factor = 0.68;
            else
                factor = 0.65;

            double result = vo2max * 1000 / (int)user.weight * factor;
            VO2 = result;
            console.SetVO2max(result);
            SecureVO2max();
        }

        public void SecureVO2max()
        {
            for (int i = 0; i < RecordedHF.Count; i++)
            {
                if (i > 0)
                {
                    if (RecordedHF[i - 1] - RecordedHF[i] > 5 || RecordedHF[i - 1] - RecordedHF[i] < -5)
                    {
                        Secure = false;
                    }
                }
            }

            for (int i = 0; i < RecordedResistance.Count; i++)
            {
                if (i > 0)
                {
                    if (RecordedResistance[i - 1] - RecordedResistance[i] > 5 || RecordedResistance[i - 1] - RecordedResistance[i] < -5)
                    {
                        Secure = false;
                    }
                }
            }

            console.SetSecure(Secure);
        }
    }
}
