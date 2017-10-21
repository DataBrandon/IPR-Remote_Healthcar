using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading;
using UserData;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Collections.Generic;

namespace Remote_Healtcare_Console
{
    class Bike : Kettler {
        private bool start;
        private SerialCommunicator serialCommunicator;
        private Client client;
        private string hashcode;
        private List<int> RecordedHF;

        private Timer WarmingUpTimer, MainTestTimer, CooldownTimer;
        private bool WarmingUpState, MainTestState, CooldownState;

        public Bike(string port, Console console, Client client) : base(console) {
            this.client = client;
            start = false;
            serialCommunicator = new SerialCommunicator(port);

            WarmingUpState = false;
            MainTestState = false;
            CooldownState = false;

            WarmingUpTimer = new Timer(2 * 60000);
            MainTestTimer = new Timer(6 * 60000);
            CooldownTimer = new Timer(1 * 60000);

            WarmingUpTimer.Elapsed += WarmingUpTimer_Elapsed;
            MainTestTimer.Elapsed += MainTestTimer_Elapsed;
            CooldownTimer.Elapsed += CooldownTimer_Elapsed;
        }

        private void WarmingUpTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            WarmingUpState = false;
            MainTestTimer.Start();
            MainTestState = true;
        }

        private void MainTestTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MainTestState = false;
            CooldownTimer.Start();
            CooldownState = true;
        }

        private void CooldownTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CooldownState = false;
        }

        private void starttest()
        {
            Timer secondTimer = new Timer(1000);
         
            if(serialCommunicator.IsConnected() && start) {

                //new Thread();
                //Thread.Sleep(500);
                Reset();
                Thread.Sleep(500);
                SetManual();
                Thread.Sleep(500);
                Run();
            }
        }

        private void SetChanges()
        {
 //           JObject obj = client.ReadMessage();
//
  //          switch ((string)obj["id"])
    //        {
      //          case ("setResistance"):
      //              int resistance = (int)obj["data"]["resistance"];
       //             SetResistance(resistance);
       //             break;
        //        case ("chat"):
         //           string message = (string)obj["data"]["message"];
         //           new Thread(() => console.AddMessage(message)).Start();
          //          break;
           //     case "setdoctor":
            //        client.SendMessage(obj);
             //       break;
             //   case ("start"):
             //       BikeThread.Start();
             //       break;
             //   case ("stop"):
              //      BikeThread.Abort();
              //      break;
            //}
        }

        public override void Start() {
            start = true;
            serialCommunicator.OpenConnection();
        }

        public override void Stop() {
            start = false;
            SetResistance(25);
            serialCommunicator.CloseConnection();
        }

        private void Run()
        {
            WarmingUpState = true;
            WarmingUpTimer.Start();
            while (serialCommunicator.IsConnected() && start) {
                Update();
                Thread.Sleep(500);
            }
        }

        public override void Reset() {
            serialCommunicator.SendMessage("RS");
            RecordedData.Clear();
        }

        public override void SetManual() {
            serialCommunicator.SendMessage("CM");
            if (serialCommunicator.ReadInput() != "RUN") {
                Thread.Sleep(500);
                serialCommunicator.ReadInput();
            }
        }

        public override void SetResistance(int resistance) {
            int trueResistance;
            if (resistance > 400) {
                trueResistance = 400;
            }
            else if (resistance < 25) {
                trueResistance = 25;
            }
            else {
                trueResistance = resistance;
            }
            serialCommunicator.SendMessage("PW " + trueResistance);
        }

        public override void SetTime(int mm, int ss) {
            string time = (mm.ToString() + ss.ToString());
            serialCommunicator.SendMessage("PT " + time);
            serialCommunicator.ReadInput();
        }

        public override void SetDistance(int distance) {
            int trueDistance;
            if (distance > 999) {
                trueDistance = 999;
            }
            else if (distance < 0) {
                trueDistance = 0;
            }
            else {
                trueDistance = distance;
            }
            serialCommunicator.SendMessage("PD " + trueDistance);
            serialCommunicator.ReadInput();
        }

        public override void Update() {
            serialCommunicator.SendMessage("ST");
            string data = serialCommunicator.ReadInput();
            data = data.Replace("\r", "");
            string[] dataSplitted = data.Split('\t');

            BikeData bikeData = new BikeData(
                int.Parse(dataSplitted[0]), int.Parse(dataSplitted[1]),
                dataSplitted[2],
                int.Parse(dataSplitted[3]), int.Parse(dataSplitted[4]), int.Parse(dataSplitted[5]),
                dataSplitted[6],
                int.Parse(dataSplitted[7]));

            if (RecordedData.Count == 0) {
                RecordedData.Add(bikeData);
            }
            else if (RecordedData.Last().Time != bikeData.Time) {
                RecordedData.Add(bikeData);
            }
            
            client.SendMessage(new
            {
                id = "sendData",
                data = new
                {
                    bikeData = bikeData
                }
            });

            //SetDataToGUI();

            if (WarmingUpState)
            {
                if (bikeData.Resistance > 25)
                    SetResistance(25);
            }
            else if (MainTestState)
            {
                if (bikeData.Time.Seconds == 0 || (bikeData.Time.Seconds % 15 == 0 && bikeData.Time.Minutes >= 4) )
                {
                    if (RecordedHF.Count > 0)
                        if (RecordedHF.Last() - bikeData.Pulse > 5 || RecordedHF.Last() - bikeData.Pulse < -5)
                            if (bikeData.Resistance - 25 > 130)
                                SetResistance(bikeData.Resistance - 25);

                    RecordedHF.Add(bikeData.Pulse);
                }
                if (bikeData.Pulse <= 130 && bikeData.Time.Seconds % 10 == 0)
                    SetResistance(bikeData.Resistance + 25);
            }
            else if (CooldownState)
            {
                if (bikeData.Resistance != 75)
                    SetResistance(75);
            }
            else
                Stop();

            if(console.user.maxHF != null)
                if (bikeData.Pulse >= console.user.maxHF)
                    Stop();
        }
        
        public double calculateVO2MaX()
        {
            //List<int> tempHF = RecordedHF.

            return 0.0;
        }
    }
}
