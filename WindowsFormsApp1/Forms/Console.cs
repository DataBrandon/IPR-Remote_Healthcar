using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UserData;

using System.Threading;
using System.Drawing;

namespace Remote_Healtcare_Console
{
    partial class Console : Form
    {
        private Kettler bike;
        private ComboBox combo;
        public string path;
        public ISet<BikeData> data;
        private Client client;
        public User user;
        public int NewResistence, OldResistance;
        public bool RPMIndacationEnabled;

        public Console(Client client, User user)
        {
            InitializeComponent();
            this.client = client;
            this.user = user;
            combo = comPorts;
            combo.Items.Clear();
            combo.Items.Add("Simulator");
            combo.Items.AddRange(SerialPort.GetPortNames());
            RPM_Indication_Picture.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        
        private void BStart_Click(object sender, EventArgs e)
        {
            combo.Focus();
            if (combo.SelectedItem.Equals("Simulator"))
            {

                OpenFileDialog browseFileDialog = new OpenFileDialog();
                browseFileDialog.Filter = "JSON (.json)|*.json;";
                browseFileDialog.InitialDirectory = Directory.GetCurrentDirectory();

                if (browseFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = Path.GetFullPath(browseFileDialog.FileName);
                    string json = File.ReadAllText(path);
                    JArray openedData = (JArray)JsonConvert.DeserializeObject(json);

                    data = (ISet<BikeData>)openedData.ToObject(typeof(ISet<BikeData>));
                }

                bike = new BikeSimulator(this);
                bike.Start();
            }
            else
            {
                client.SendMessage(new
                {
                    id = "startrecording",
                    data = new
                    {
                    }
                });
                bike = new Bike(combo.SelectedItem.ToString(), this, client);
                bike.Start();
            }
        }

        public void FlipRPMIndication(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(FlipRPMIndication), new object[] { enable });
                return;
            }
            this.RPMIndacationEnabled = enable;
            if(!enable)
                RPM_Indication_Picture.Image = null;
            RPM_Indication_Picture.Enabled = enable;
            RPM_Indication_Picture.Invalidate();
            RPM_Indication_Picture.Update();
            RPM_Indication_Picture.Refresh();
        }

        internal void SetTime(string v)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetTime), new object[] { v });
                return;
            }
            Timerlabel.Text = v;
            Timerlabel.Invalidate();
            Timerlabel.Update();
            Timerlabel.Refresh();
        }

        internal void SetRPM(string v)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetRPM), new object[] { v });
                return;
            }
            Rpm_Lbl.Text = v;
            Rpm_Lbl.Invalidate();
            Rpm_Lbl.Update();
            Rpm_Lbl.Refresh();

            if (RPMIndacationEnabled)
            {
                if (int.Parse(v) > 60)
                    RPM_Indication_Picture.Image = Properties.Resources.red_down;
                else if (int.Parse(v) < 50)
                    RPM_Indication_Picture.Image = Properties.Resources.green_up;
                else
                    RPM_Indication_Picture.Image = Properties.Resources.keep_on_going;
                RPM_Indication_Picture.Invalidate();
                RPM_Indication_Picture.Update();
                RPM_Indication_Picture.Refresh();
            }
        }

        internal void SetSecure(bool secure)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<bool>(SetSecure), new object[] { secure });
                return;
            }
            if (secure)
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
            Application.DoEvents();
        }

        internal void SetNewResistance(int resistance)
        {
            this.NewResistence = resistance;
            if (NewResistence > OldResistance)
                NewResistence_Lbl.Text = $">>> {resistance}";
            else
                NewResistence_Lbl.Text = $"<<< {resistance}";
            NewResistence_Lbl.ForeColor = Color.Red;
        }

        public void AddDataToChart(int RPM, int Pulse, int Resistance)
        {
            Chart.Series.FindByName("RPM").Points.AddY(RPM);
            Chart.Series.FindByName("Pulse").Points.AddY(Pulse);
            Chart.Series.FindByName("Resistance").Points.AddY(Resistance);
        }

        internal void SetResistance(string v)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetResistance), new object[] { v });
                return;
            }
            OldResistance = int.Parse(v);
            if (int.Parse(v) == NewResistence && NewResistence_Lbl.Text != "")
            {
                NewResistence_Lbl.Text = "";
                NewResistence_Lbl.ForeColor = Color.White;
            }
            Resistance_Lbl.Text = v;
            Resistance_Lbl.Invalidate();
            Resistance_Lbl.Update();
            Resistance_Lbl.Refresh();
            NewResistence_Lbl.Invalidate();
            NewResistence_Lbl.Update();
            NewResistence_Lbl.Refresh();
        }

        internal void SetOldPulse(string v)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetOldPulse), new object[] { v });
                return;
            }
            Old_Pulse_Lbl.Text = v;
            Old_Pulse_Lbl.Invalidate();
            Old_Pulse_Lbl.Update();
            Old_Pulse_Lbl.Refresh();
        }

        internal void SetPulse(string v)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetPulse), new object[] { v });
                return;
            }
            Pulse_Lbl.Text = v;
            Pulse_Lbl.Invalidate();
            Pulse_Lbl.Update();
            Pulse_Lbl.Refresh();
        }

        public void SetFaseLabel(string fase)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetFaseLabel), new object[] { fase });
                return;
            }
            FaseLabel.Text = fase;
            FaseLabel.Invalidate();
            FaseLabel.Update();
            FaseLabel.Refresh();
        }

        public void Update(BikeData data, int oldPulse, bool steady)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<BikeData, int, bool>(Update), new object[] { data, oldPulse, steady });
                return;
            }

            SetSteady(steady);
            SetRPM(data.Rpm.ToString());
            SetResistance(data.Resistance.ToString());
            SetPulse(data.Pulse.ToString());
            SetOldPulse(oldPulse.ToString());

            Application.DoEvents();
        }

        internal void SetSteady(bool steady)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<bool>(SetSteady), new object[] { steady });
                return;
            }
            if (steady)
                Steady_State.BackColor = Color.Lime;
            else
                Steady_State.BackColor = Color.Red;
            Steady_State.Invalidate();
            Steady_State.Update();
            Steady_State.Refresh();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Environment.Exit(0);
            base.OnFormClosed(e);
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            client.SendMessage("bye");
        }

        internal void SetVO2max(double v)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<double>(SetVO2max), new object[] { v });
                return;
            }
            VO2max_Lbl.Text = v.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            VO2max_Lbl.Invalidate();
            VO2max_Lbl.Update();
            VO2max_Lbl.Refresh();
            Application.DoEvents();
        }
    }
}
