﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SkiRunRater
{
    /// <summary>
    /// method to write all ski run information to the date file
    /// </summary>
    public class SkiRunRepositorJSON : IDisposable
    {
        private List<SkiRun> _skiRuns;

        public SkiRunRepositorJSON()
        {
            _skiRuns = ReadSkiRunsData(DataSettings.dataFilePath);
        }

        /// <summary>
        /// method to read all ski run information from the data file and return it as a list of SkiRun objects
        /// </summary>
        /// <param name="dataFilePath">path the data file</param>
        /// <returns>list of SkiRun objects</returns>
        public List<SkiRun> ReadSkiRunsData(string dataFilePath)
        {
            string jsonText;
            List<SkiRun> skiRuns = new List<SkiRun>();

            StreamReader sReader = new StreamReader(DataSettings.dataFilePath);

            using (sReader)
            {
                jsonText = sReader.ReadToEnd();
            }

            skiRuns = JsonConvert.DeserializeObject<List<SkiRun>>(jsonText);

            return skiRuns;
        }

        /// <summary>
        /// method to write all of the list of ski runs to the text file
        /// </summary>
        public void WriteSkiRunsData()
        {
            StreamWriter sWriter = new StreamWriter(DataSettings.dataFilePath, false);

            string jsonText = JsonConvert.SerializeObject(_skiRuns, Formatting.Indented);

            using (sWriter)
            {
                sWriter.Write(jsonText);
            }
        }

        /// <summary>
        /// method to add a new ski run
        /// </summary>
        /// <param name="skiRun"></param>
        public void InsertSkiRun(SkiRun skiRun)
        {
            _skiRuns.Add(skiRun);

            WriteSkiRunsData();
        }

        /// <summary>
        /// method to delete a ski run by ski run ID
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteSkiRun(int ID)
        {
            _skiRuns.RemoveAll(sr => sr.ID == ID);

            WriteSkiRunsData();
        }

        /// <summary>
        /// method to update an existing ski run
        /// </summary>
        /// <param name="skiRun">ski run object</param>
        public void UpdateSkiRun(SkiRun skiRun)
        {
            DeleteSkiRun(skiRun.ID);
            InsertSkiRun(skiRun);

            WriteSkiRunsData();
        }

        /// <summary>
        /// method to return a ski run object given the ID
        /// </summary>
        /// <param name="ID">int ID</param>
        /// <returns>ski run object</returns>
        public SkiRun GetSkiRunByID(int ID)
        {
            SkiRun skiRun = null;

            skiRun = _skiRuns.FirstOrDefault(sr => sr.ID == ID);

            return skiRun;
        }

        /// <summary>
        /// method to return a list of ski run objects
        /// </summary>
        /// <returns>list of ski run objects</returns>
        public List<SkiRun> GetSkiAllRuns()
        {
            return _skiRuns;
        }

        /// <summary>
        /// method to query the data by the vertical of each ski run in feet
        /// </summary>
        /// <param name="minimumVertical">int minimum vertical</param>
        /// <param name="maximumVertical">int maximum vertical</param>
        /// <returns></returns>
        public List<SkiRun> QueryByVertical(int minimumVertical, int maximumVertical)
        {
            List<SkiRun> matchingSkiRuns = new List<SkiRun>();

            matchingSkiRuns = _skiRuns.Where(sr => sr.Vertical >= minimumVertical && sr.Vertical <= maximumVertical).ToList();

            return matchingSkiRuns;
        }

        /// <summary>
        /// method to handle the IDisposable interface contract
        /// </summary>
        public void Dispose()
        {
            _skiRuns = null;
        }
    }
}