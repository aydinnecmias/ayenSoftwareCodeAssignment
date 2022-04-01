using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ayen
{
    public class AyenUrunler
    {
        public List<Urun> Urunler { get; set; }
    }
    public class Urun
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

        public List<Varyant> Varyantlar { get; set; }
    }

    public class Varyant
    {
        public string Sku { get; set; }
        public int Stok { get; set; }
        public double Fiyat { get; set; }
        public List<Ozellik> Ozellikler { get; set; }

        internal static object FromCsv(string v)
        {
            throw new NotImplementedException();
        }
    }
    public sealed class VaryantMap : ClassMap<Varyant>
    {
        public VaryantMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Sku).Name("Sku");
            Map(m => m.Stok).Name("Stok");
            Map(m => m.Fiyat).Name("Fiyat");

        }
    }
    public class Ozellik
    {
        public string Ad { get; set; }
        public string Deger { get; set; }
    }

}
