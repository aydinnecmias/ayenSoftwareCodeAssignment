using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ayen
{
    public class JSONOperations
    {
        public static List<Urun> DeserializeJson()
        {
            WebClient wc = new WebClient();
            {
                var url = wc.DownloadString("https://cdn.ayensoftware.com/00Coding/01/products.json");

                var data = JsonConvert.DeserializeObject<List<Urun>>(url); // Deserialize Json 

                var FilteredData = data.Where(x => !x.Brand.ToLower().Contains("adidas")).ToList();  // Filtering



                return FilteredData;

                // Ling GroupBy Color , Product name ile gruplanacak.
                #region test
                //var MaviUrunler  = FilteredData.Where(x => x.Brand == "Mavi").ToList();

                //foreach (var urun in MaviUrunler)
                //{
                //    Console.WriteLine(urun.Name + " " + urun.Color);

                //    //Console.WriteLine(urun.ProductCode + " " + urun.Name + " " + urun.Brand + " " + urun.Color + " " + urun.Size + " " + urun.SKU);
                //} 
                #endregion
            }
        }

        // Json Dosyasına yazma işleni yapacak.
        public static void WriteToJson()
        {
            Varyant varyant = new Varyant();

            var jsonVaryant = JsonConvert.SerializeObject(varyant);
            string fileName = "AyenUrunler.json";

            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }
            else
            {
                System.IO.File.WriteAllText(@$"C:\Users\aydin\Desktop\ayen\{fileName}", jsonVaryant);
            }


        }
    }
}
