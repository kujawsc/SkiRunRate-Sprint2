using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRunRater
{
    public class DataSettings
    {
        //public const string dataFilePath = "Data\\Data.txt";
        public const string dataFilePath = "Data\\Data.xml";
        //public const string dataFilePath = "Data\\Data.json";

        private string _dataFilePath = "Data\\Data.";

        public string DataFilePath
        {
            get { return _dataFilePath; }
            set { _dataFilePath = value; }
        }


        public DataSettings(AppEnum.DataType userDataType)
        {
            string suffix = "";

            switch (userDataType)
            {
                case AppEnum.DataType.None:
                    break;
                case AppEnum.DataType.CSV:
                    suffix = "csv";
                    break;
                case AppEnum.DataType.XML:
                    suffix = "xml";
                    break;
                case AppEnum.DataType.JSON:
                    suffix = "json";
                    break;
                case AppEnum.DataType.Quit:
                    break;
                default:
                    break;
            }

            _dataFilePath += suffix;
        }
    }


}