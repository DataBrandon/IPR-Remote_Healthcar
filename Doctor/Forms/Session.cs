using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Windows.Forms;
using UserData;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Doctor
{
    public partial class Session : Form
    {
        User patient;
        Client client;

        List<BikeData> graphhistory;
        List<int> pulsehistory;
        List<int> roundhistory;
        List<double> speedhistory;
        List<int> distancehistory;
        List<int> resistancehistory;
        List<int> energyhistory;
        List<int> generatedhistory;

        object sessionLock = new object();

        Thread UpdateThread;
        Thread GraphThread;

        public Session(List<BikeData> list)
        {
            InitializeComponent();

            int AvgPulse = 0;
            int AvgRPM = 0;
            double AvgSpeed = 0;
            int AvgResistance = 0;

            foreach (BikeData data in list)
            {
                grafiek.Series.FindByName("Hartslag").Points.AddY(data.Pulse);
                AvgPulse += data.Pulse;
                grafiek.Series.FindByName("RPM").Points.AddY(data.Rpm);
                AvgRPM += data.Rpm;
                grafiek.Series.FindByName("Snelheid").Points.AddY(data.Speed);
                AvgSpeed += data.Speed;
                grafiek.Series.FindByName("Afstand").Points.AddY(data.Distance);
                grafiek.Series.FindByName("Weerstand").Points.AddY((data.Resistance - 25) * 100 / 375);
                AvgResistance += (data.Resistance - 25) * 100 / 375;
            }

            lblPulse.Text = (AvgPulse / list.Count).ToString();
            lblRoundMin.Text = (AvgRPM / list.Count).ToString();
            lblSpeed.Text = (AvgSpeed / list.Count).ToString();
            lblDistance.Text = list[list.Count - 1].Distance.ToString();
            lblResistence.Text = (AvgResistance / list.Count).ToString();
            lblEnergy.Text = list[list.Count - 1].Energy.ToString();
            lblTime.Text = list[list.Count - 1].Time.ToString();
        }

        public void SetPulse(String s)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetPulse), new object[] { s });
                return;
            }
            lblPulse.Text = s;
            lblPulse.Invalidate();
            lblPulse.Update();
            lblPulse.Refresh();
        }

        public void SetRoundMin(String s)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetRoundMin), new object[] { s });
                return;
            }
            lblRoundMin.Text = s;
            lblRoundMin.Invalidate();
            lblRoundMin.Update();
            lblRoundMin.Refresh();
        }

        public void SetSpeed(String s)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetSpeed), new object[] { s });
                return;
            }
            lblSpeed.Text = s;
            lblSpeed.Invalidate();
            lblSpeed.Update();
            lblSpeed.Refresh();
        }

        public void SetDistance(String s)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetDistance), new object[] { s });
                return;
            }
            lblDistance.Text = s;
            lblDistance.Invalidate();
            lblDistance.Update();
            lblDistance.Refresh();
        }

        public void SetEnergy(String s)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetEnergy), new object[] { s });
                return;
            }
            lblEnergy.Text = s;
            lblEnergy.Invalidate();
            lblEnergy.Update();
            lblEnergy.Refresh();
        }

        public void SetTime(String s)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetTime), new object[] { s });
                return;
            }
            lblTime.Text = s;
            lblTime.Invalidate();
            lblTime.Update();
            lblTime.Refresh();
        }
        
        private void AddToGraphHistory(BikeData bike)
        {
            lock (sessionLock)
            {
                pulsehistory.Add(bike.Pulse);
                roundhistory.Add(bike.Rpm);
                speedhistory.Add(bike.Speed);
                distancehistory.Add(bike.Distance);
                resistancehistory.Add(bike.Resistance);
                energyhistory.Add(bike.Energy);
                generatedhistory.Add(bike.Power);
            }
            
            if (grafiek.IsHandleCreated)
            {
                this.Invoke(
                    (MethodInvoker)delegate
                        {
                            UpdateGrafiek();
                        }
                     );
            }
            else
            {
                Console.WriteLine("ERROR Grafiek niet aangemaakt");
            }
        }

        private void UpdateGrafiek()
        {
            lock (sessionLock)
            {
                foreach (var Serie in grafiek.Series)
                {
                    Serie.Points.Clear();
                }
            }

            lock (sessionLock)
            {
                foreach (int hartslag in pulsehistory)
                {
                    grafiek.Series.FindByName("Hartslag").Points.AddY(hartslag);
                }
            }

            lock (sessionLock)
            {
                foreach (int round in roundhistory)
                {
                    grafiek.Series.FindByName("RPM").Points.AddY(round);
                }
            }

            lock (sessionLock)
            {
                foreach (int speed in speedhistory)
                {
                    grafiek.Series.FindByName("Snelheid").Points.AddY(speed);
                }
            }

            lock (sessionLock)
            {
                foreach (int distance in distancehistory)
                {
                    grafiek.Series.FindByName("Afstand").Points.AddY(distance);
                }
            }

            lock (sessionLock)
            {
                foreach (int weerstand in resistancehistory)
                {
                    grafiek.Series.FindByName("Weerstand").Points.AddY((weerstand - 25) * 100 / 375);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }   

}

