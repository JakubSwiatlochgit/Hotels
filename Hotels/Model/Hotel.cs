using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Model
{
    public class Hotel
    {
        [Index(0)]
        public int id { get; set; }

        [Index(1)]
        public string nazwa_wlasna { get; set; }

        [Index(2)]
        public string telefon { get; set; }
        [Index(3)]
        public string email { get; set; }

        [Index(4)]
        public string charakter_uslug { get; set; }
        [Index(5)]
        public string kategoria_obiektu { get; set; }

        [Index(6)]
        public string rodzaj_obiektu { get; set; }

        [Index(7)]
        public string adres { get; set; }
    }
}
