using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Windows.Forms;
using UserData;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Doctor {
    public partial class Session : Form {
        private User patient;
        private Client client;

        private List<BikeData> sessionAllData;
        private List<BikeData> graphhistory;
        private List<int> pulsehistory;
        private List<int> roundhistory;
        private List<double> speedhistory;
        private List<int> distancehistory;
        private List<int> resistancehistory;
        private List<int> energyhistory;
        private List<int> generatedhistory;
        private List<int> RecordedHF;
        private List<int> RecordedResistance;

        private object sessionLock = new object();

        private Thread UpdateThread;

        public Session(User patient, ref Client client, string SessionDate) {
            InitializeComponent();
            this.patient = patient;
            this.client = client;
            this.sessionAllData = new List<BikeData>();

            pulsehistory = new List<int>();
            speedhistory = new List<double>();
            roundhistory = new List<int>();
            distancehistory = new List<int>();
            resistancehistory = new List<int>();
            energyhistory = new List<int>();
            generatedhistory = new List<int>();

            RecordedHF = new List<int>();
            RecordedResistance = new List<int>();

            sessionDate.Text = SessionDate;

            dynamic request = new
            {
                id = "oldsession",
                data = new
                {
                    hashcode = patient.Hashcode,
                    file = SessionDate
                }
            };


            List<BikeData> datas;
            lock (client.ReadAndWriteLock)
            {
                client.SendMessage(request);
                string obj = client.ReadMessage();
                datas = (List<BikeData>)((JArray)JsonConvert.DeserializeObject(obj)).ToObject(typeof(List<BikeData>));
            }
            sessionAllData.AddRange(datas);
            new Thread(() => updateGraphFromOtherThread(datas)).Start();
        }

        private void updateGraphFromOtherThread(List<BikeData> datas) {
            
            foreach (BikeData data in datas) {
                if(data.Time == new TimeSpan(0,2,0) || data.Time == new TimeSpan(0, 3, 0) || (data.Time.Minutes >= 4 && data.Time.Minutes < 6 && data.Time.Seconds % 15 == 0) || data.Time == new TimeSpan(0,6,0))
                {
                    RecordedHF.Add(data.Power);
                    RecordedResistance.Add(data.Resistance);
                }
                if (data.Time == new TimeSpan(0, 6, 0))
                    CalculateVO2MaX(patient, (int)RecordedHF.Average(), (int)RecordedResistance.Max());

                updateAll(data);
                AddToGraphHistory(data);
            }
        }

        private void updateAll(BikeData data) {
            SetTime(data.Time.ToString());
            Application.DoEvents();
        }

        public void SetTime(String s) {
            if (InvokeRequired) {
                this.BeginInvoke(new Action<string>(SetTime), new object[] { s });
                return;
            }
            lblTime.Text = s;
            lblTime.Invalidate();
            lblTime.Update();
            lblTime.Refresh();
        }

        private void AddToGraphHistory(BikeData bike) {
            lock (sessionLock) {
                pulsehistory.Add(bike.Pulse);
                roundhistory.Add(bike.Rpm);
                speedhistory.Add(bike.Speed);
                distancehistory.Add(bike.Distance);
                resistancehistory.Add(bike.Resistance);
                energyhistory.Add(bike.Energy);
                generatedhistory.Add(bike.Power);
            }

            if (grafiek.IsHandleCreated) {
                this.Invoke((MethodInvoker)delegate {
                    updateGrafiek();
                });
            }
            else {
                Console.WriteLine("ERROR Grafiek niet aangemaakt");
            }
        }

        private void updateGrafiek() {
            lock (sessionLock) {
                foreach (var Serie in grafiek.Series) {
                    Serie.Points.Clear();
                }
            }

            lock (sessionLock) {
                foreach (int hartslag in pulsehistory) {
                    grafiek.Series.FindByName("Pulse").Points.AddY(hartslag);
                }
            }

            lock (sessionLock) {
                foreach (int round in roundhistory) {
                    grafiek.Series.FindByName("RPM").Points.AddY(round);
                }
            }

            lock (sessionLock) {
                foreach (int weerstand in resistancehistory) {
                    grafiek.Series.FindByName("Resistance").Points.AddY((weerstand - 25) * 100 / 375);
                }
            }
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
            SetVO2max(result);
            
            bool Secure = true;
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

            SecureVO2max(Secure);
        }

        private void SetVO2max(double result)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(() => 
                {
                    VO2max_Lbl.Text = result.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    VO2max_Lbl.Invalidate();
                    VO2max_Lbl.Update();
                    VO2max_Lbl.Refresh();

                    patientName.Text = patient.FullName;
                    patientName.Invalidate();
                    patientName.Update();
                    patientName.Refresh();

                }));
            }
        }

        public void SecureVO2max(bool Secure)
        {

            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(() => 
                {
                    if (Secure)
                    {
                        Secure_Lbl.Text = "(Secure)";
                    }
                    else
                    {
                        Secure_Lbl.Text = "(Insecure)";
                    }
                    Secure_Lbl.Invalidate();
                    Secure_Lbl.Update();
                    Secure_Lbl.Refresh();
                }));
            }
        }
    }
}