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

        public Console(Client client, User user)
        {
            InitializeComponent();
            this.client = client;
            this.user = user;
            combo = comPorts;
            combo.Items.Clear();
            combo.Items.AddRange(SerialPort.GetPortNames());
        }
        
        private void BStart_Click(object sender, EventArgs e)
        {
            combo.Focus();

            bike = new Bike(combo.SelectedItem.ToString(), this, client);
            bike.Start();
        }

        public void SetTimerLabel(TimeSpan time)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<TimeSpan>(SetTimerLabel), new object[] { time });
                return;
            }
            Timerlabel.Text = time.ToString();
            Timerlabel.Invalidate();
            Timerlabel.Update();
            Timerlabel.Refresh();
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

        public void SetRPMIndication(int rpm)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<int>(SetRPMIndication), new object[] { rpm });
                return;
            }
            if (rpm > 60)
                RPM_Indication_Picture.Image = Properties.Resources.red_down;
            else if(rpm < 50)
                RPM_Indication_Picture.Image = Properties.Resources.green_up;
            else
                RPM_Indication_Picture.Image = Properties.Resources.keep_on_going;
            RPM_Indication_Picture.Invalidate();
            RPM_Indication_Picture.Update();
            RPM_Indication_Picture.Refresh();
            Application.DoEvents();
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
    }
}
