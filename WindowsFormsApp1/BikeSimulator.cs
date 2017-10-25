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

        private bool WarmingUpState, MainTestState, Steady;

        public BikeSimulator(Console console) : base(console) {
            this.console = console;
            data = console.data;
            count = 0;
            BikeThread = new Thread(Update);
            timer = new System.Timers.Timer(100);
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
                console.SetVO2max(calculateVO2MaX(console.user, (int)RecordedHF.Average(), (int)RecordedResistance.Average()));
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

        public double VO2max(int age, int sex, int shr)
        {
            return (220 - age - 73 - (sex * 10)) / (shr - 73 - (sex * 10));
        }

        public double VO2I(int watt, int weight)
        {
            return (1.8 * (((watt * 6.1183) / 2) / weight) + 7);
        }

        public double calculateVO2MaX(User user, int shr, int watt)
        {
            int sex;
            if (user.male)
                sex = 0;
            else
                sex = 1;
            double vmax = VO2max(user.age, sex, shr);
            double vmai = VO2I(watt, user.weight);
            return vmax * vmai;
        }
    }
}
