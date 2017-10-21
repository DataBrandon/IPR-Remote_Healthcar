using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UserData;

using System.Threading;

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
            combo = comPorts;
            combo.Items.Clear();
            combo.Items.AddRange(SerialPort.GetPortNames());
        }

        

        private void BStart_Click(object sender, EventArgs e)
        {
            combo.Focus();

            //new Thread(() => test()).Start();

            bike = new Bike(combo.SelectedItem.ToString(), this, client);
            bike.Start();
        }

        public void setTimerLabel(int seconds)
        {
            Timerlabel.Text = seconds.ToString();
        }

        public void setFaseLabel(string fase)
        {
            FaseLabel.Text = fase;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Environment.Exit(0);
            base.OnFormClosed(e);
        }
        
        public void AddMessage(String value)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AddMessage), new object[] { value });
                return;
            }
            
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            client.SendMessage("bye");
        }
    }
}
