using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData;

namespace Server
{
    public class BikeSession
    {
        private DateTime sessionDateTime;
        private string userHash;
        public List<BikeData> Data { get; set; }
        public List<BikeData> LatestData { get; set; }
        public string pathToSessionFile;

        public BikeSession(string userHash)
        {
            this.userHash = userHash;
            sessionDateTime = DateTime.Now;
            Data = new List<BikeData>();
            LatestData = new List<BikeData>();
            string pathToUserDir = Directory.GetCurrentDirectory() + @"\ClientData\" + userHash + @"\";
            pathToSessionFile = pathToUserDir + sessionDateTime.Day + "-" + sessionDateTime.Month + "-" + sessionDateTime.Year + "  " + sessionDateTime.Hour + "." + sessionDateTime.Minute + "." + sessionDateTime.Second + ".json";
            if (!Directory.Exists(pathToUserDir))
            {
                Directory.CreateDirectory(pathToUserDir);
            }
        }

        public void SaveSessionToFile()
        {
            try
            {
                File.WriteAllText(pathToSessionFile, JsonConvert.SerializeObject(Data, Formatting.Indented));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
