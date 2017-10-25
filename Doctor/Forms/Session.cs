using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Windows.Forms;
using UserData;
using System.Collections.Generic;
using Newtonsoft.Json;

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
                if (data.VO2max == null && data.Secure == null)
                {
                    updateAll(data);
                    AddToGraphHistory(data);
                }
                else
                {
                    if (InvokeRequired)
                    {
                        this.BeginInvoke(new Action(() => SetVO2max((double)data.VO2max, (bool)data.Secure)));
                    }
                }
            }
        }

        private void SetVO2max(double VO2max, bool secure)
        {
            VO2max_Lbl.Text = VO2max.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture);
            if (secure)
                Secure_Lbl.Text = "(Secure)";
            else
                Secure_Lbl.Text = "(Insecure)";
            patientName.Text = patient.FullName;
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
    }
}