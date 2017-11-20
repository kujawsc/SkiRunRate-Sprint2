using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SkiRunRater
{
    public class InitializeDataFileJSON
    {

        public static void AddTestData(string dataFilePath)
        {
            List<SkiRun> skiRuns = new List<SkiRun>();

            skiRuns.Add(new SkiRun() { ID = 1, Name = "Buck", Vertical = 325 });
            skiRuns.Add(new SkiRun() { ID = 2, Name = "Buckaroo", Vertical = 325 });
            skiRuns.Add(new SkiRun() { ID = 3, Name = "Hoot Owl", Vertical = 325 });
            skiRuns.Add(new SkiRun() { ID = 4, Name = "Shelburg's Chute", Vertical = 325 });

            WriteAllSkiRuns(skiRuns, dataFilePath);
        }

        /// <summary>
        /// method to write all ski run info to the data file
        /// </summary>
        /// <param name="skiRuns">list of ski run info</param>
        /// <param name="dataFilePath">path to the data file</param>
        public static void WriteAllSkiRuns(List<SkiRun> skiRuns, string dataFilePath)
        {
            string jsonText;

            StreamWriter sWriter = new StreamWriter(DataSettings.dataFilePath, false);

            jsonText = JsonConvert.SerializeObject(skiRuns, Formatting.Indented);

            using (sWriter)
            {
                sWriter.Write(jsonText);
            }
        }
    }
}