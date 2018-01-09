using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roba.DataBase_Objects
{
    class Izvjestaj
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public decimal Cijena { get; set; }
        public int Komada { get; set; }
        public decimal Ukupno { get; set; }
        public decimal Sveukupno { get; set; }
        public DateTime Date { get; set; }
    }
}
