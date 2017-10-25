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
        private List<int> RecordedResistance;
        private List<BikeData> bikeDataList;
        private TimeSpan minusTimeSpan;
        private double VO2;

        private bool WarmingUpState, MainTestState, CooldownState, CorrectResult, Steady, Secure;

        public Bike(string port, Console console, Client client) : base(console) {
            this.client = client;
            start = false;
            serialCommunicator = new SerialCommunicator(port);
            RecordedHF = new List<int>();
            RecordedResistance = new List<int>();
            bikeDataList = new List<BikeData>();
            hashcode = console.user.Hashcode;

            WarmingUpState = false;
            MainTestState = false;
            CooldownState = false;
            CorrectResult = false;
            Steady = false;
            Secure = true;
            minusTimeSpan = new TimeSpan(0, 0, 0);
        }

        private void Starttest()
        {
            if(serialCommunicator.IsConnected() && start) {
                Reset();
                Thread.Sleep(500);
                SetManual();
                Thread.Sleep(500);
                Run();
            }
        }

        public override void Start() {
            start = true;
            WarmingUpState = true;
            serialCommunicator.OpenConnection();
            Starttest();
        }

        public override void Stop() {
            start = false;
            SetResistance(25);
            serialCommunicator.CloseConnection();

            BikeData tempData = new BikeData();
            tempData.VO2max = VO2;
            tempData.Secure = Secure;
            bikeDataList.Add(tempData);

            client.SendMessage(new
            {
                id = "sendData",
                data = new
                {
                    hashcode = hashcode,
                    bikeData = bikeDataList
                }
            });
        }

        private void Run()
        {
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
            console.SetNewResistance(resistance);
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
                int.Parse(dataSplitted[7]), null, null);

            if(bikeData.Time.Minutes >= 2 && WarmingUpState)
            {
                WarmingUpState = false;
                MainTestState = true;
                console.SetFaseLabel("Main test");
                minusTimeSpan += new TimeSpan(0, 2, 0);
            }
            else if(MainTestState && bikeData.Time.Minutes >= 6)
            {
                MainTestState = false;
                CooldownState = true;
                console.SetFaseLabel("Cooling down");
                minusTimeSpan += new TimeSpan(0, 4, 0);
                SetResistance(bikeData.Resistance / 2);
                CalculateVO2MaX(console.user, (int)RecordedHF.Average(), (int)RecordedResistance.Average());
            }
            else if(CooldownState && bikeData.Time.Minutes < 7)
            {
                CooldownState = false;
                console.SetFaseLabel("Done!");
                minusTimeSpan = bikeData.Time;
                Stop();
            }
            
            if (RecordedData.Count == 0) {
                RecordedData.Add(bikeData);
            }
            else if (RecordedData.Last().Time != bikeData.Time) {
                RecordedData.Add(bikeData);

                bikeDataList.Add(bikeData);

                if (WarmingUpState)
                {
                    if (bikeData.Resistance != 100)
                    {
                       SetResistance(100);
                    }
                }
                else if (MainTestState)
                {
                    if (bikeData.Time.Seconds == 0 || (bikeData.Time.Seconds % 15 == 0 && bikeData.Time.Minutes >= 4))
                    {
                        if (RecordedHF.Count > 0)
                        {
                            if (RecordedHF.Last() - bikeData.Pulse > 5 || RecordedHF.Last() - bikeData.Pulse < -5)
                            {
                                if (bikeData.Resistance - 20 > 140)
                                {
                                    SetResistance(bikeData.Resistance - 20);
                                }
                                else if (bikeData.Rpm < 15)
                                {
                                    SetResistance(bikeData.Resistance - 20);
                                }

                                Steady = false;
                            }
                            else
                            {
                                Steady = true;
                            }
                        }

                        RecordedHF.Add(bikeData.Pulse);
                        RecordedResistance.Add(bikeData.Resistance);
                    }
                    if (bikeData.Pulse <= 130 && bikeData.Time.Seconds % 20 == 0 && bikeData.Resistance + 20 < 175)
                        SetResistance(bikeData.Resistance + 20);
                    if (bikeData.Resistance >= 175)
                        SetResistance(bikeData.Resistance - 20);
                }
                else if (!CooldownState)
                    Stop();

                console.AddDataToChart(bikeData.Rpm, bikeData.Pulse, bikeData.Resistance);

                if (console.user.maxHF != null)
                    if (bikeData.Pulse >= console.user.maxHF)
                        Stop();

                bikeData.Time = bikeData.Time - minusTimeSpan;

                if (RecordedHF.Count > 0)
                    console.Update(bikeData, RecordedHF.Last(), Steady);
                else
                    console.Update(bikeData, 0, Steady);
            }

            console.SetPulse(bikeData.Pulse.ToString());
            console.SetRPM(bikeData.Rpm.ToString());
            console.SetResistance(bikeData.Resistance.ToString());
            console.SetTime(bikeData.Time.ToString());
            console.SetSteady(Steady);
        }

        public double VO2max(int age, int sex, int shr)
        {
            return (220 - age - 73 - (sex * 10)) / (shr - 73 - (sex * 10));
        }

        public double VO2I(int watt, int weight)
        {
            return (1.8 * (((watt * 6.1183) / 2) / weight) + 7);
        }

        public void CalculateVO2MaX(User user, int shr, int watt)
        {
            int sex;
            if (user.male)
                sex = 0;
            else
                sex = 1;
            double vmax = VO2max(user.birthyear, sex, shr);
            double vmai = VO2I(watt, user.weight);

            int age = DateTime.Now.Year - user.birthyear;
            double factor;
            if (age < 25)
                factor = 1.1;
            else if (age < 35)
                factor = 1.0;
            else if (age < 40)
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

            double result = vmax * vmai * factor;
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
