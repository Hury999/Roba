using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roba.DataBase_Objects
{
    public class Artikal
    {
        public int Id { get; set; }
        public string Proizvod { get; set; }
        public string Proizvodac { get; set; }
        public int Stanje { get; set; }
        public decimal Cijena { get; set; }
        public int BarKod { get; set; }
        public string Detalji { get; set; }
    }
}
