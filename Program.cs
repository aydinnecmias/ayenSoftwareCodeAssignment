using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static ayen.JSONOperations;
using static ayen.CSVOperations;

namespace ayen
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductPriceQuantityCSV();
            DeserializeJson();
            WriteToJson();
        }
    }
}


