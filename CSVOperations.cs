using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace ayen
{
    public class CSVOperations
    {
        public static void ProductPriceQuantityCSV()
        {

            #region WebClientUrl

            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;

            string url = "https://cdn.ayensoftware.com/00coding/01/stock_prices.csv";

            var csv = wc.DownloadString(url);

            var skus = new List<string>();
            var stoks = new List<string>();
            var fiyats = new List<string>();

            using (StringReader sr = new StringReader(csv))
            {
                string line;
                int linecount = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    // row data içerisinde veriler geliyor.
                    var rowData = csv.Split(new[] { "\r\n", "\r", "\n", ";" }, StringSplitOptions.None);

                    // rowData içerisindeki verileri mod3 alınca ayrı listelere ekleyebiliyoruz. Ama daha kolay bi yolu olmalı :).
                    for (int i = 4; i < 64; i += 3)
                    {
                        skus.Add(rowData[i]);

                    }
                    for (int i = 5; i < (linecount * 3); i += 3)
                    {
                        stoks.Add(rowData[i]);
                    }
                    for (int i = 6; i < (linecount * 3); i += 3)
                    {
                        fiyats.Add(rowData[i]);
                    }
                    linecount++;
                }

                #endregion
                // UrlDen okurken string reader null dönüyor. (Deneme).


                #region UrlDenemesi
                //var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                //{
                //    Encoding = Encoding.UTF8, //  utf-8 encoding.
                //    Delimiter = ";" // noktalı virgüle göre ayırma
                //};

                //using (var reader = new StringReader("https://cdn.ayensoftware.com/00coding/01/stock_prices.csv"))
                //using (var csv = new CsvReader(reader, configuration))
                //{

                //    csv.Context.RegisterClassMap<VaryantMap>();
                //    var data = csv.GetRecords<Varyant>(); 
                #endregion

                // Dosyadan okurken sorunsuz bind edebiliyor.
                #region Dosyadan Okuma Denemesi

                //var filename = @"c:\users\aydin\desktop\ayen\ayen\data.csv";
                //var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                //{
                //    Encoding = Encoding.UTF8, //  utf-8 encoding.
                //    Delimiter = ";" // noktalı virgüle göre ayırma
                //};

                //using (var fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                //{
                //    using (var textreader = new StreamReader(fs, Encoding.UTF8))
                //    using (var csv1 = new CsvReader(textreader, configuration))
                //    {
                //        csv1.Context.RegisterClassMap<VaryantMap>();

                //        // data'da Maplenen veriler geliyor.
                //        var data = csv1.GetRecords<Varyant>(); 

                //        // jsonData içerisinde veriler geliyor.
                //        var jsonData = JSONOperations.DeserializeJson(); 

                //        // var query = from s in jsonData.Where(x => x.SKU == data.Sku) // Linq filter ile eşleştirilebilir.
                //}


                    #endregion

                }
            }
        }
    }


