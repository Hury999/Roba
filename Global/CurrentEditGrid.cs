using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roba.Global
{
//Static klasa za pohranivanje globalne varijable koja oznacava trenutni dizajn
    static class CurrentEditGrid
    {

        private static bool _Artikal;

        public static bool Artikal
        {
            get
            {
                return _Artikal;
            }
            set
            {
                if (value == true)
                {
                    _Partner = false;
                    _Izvjestaj = false;
                }
                _Artikal = value;
            }
        }

        private static bool _Partner;

        public static bool Partner
        {
            get
            {
                return _Partner;
            }
            set
            {
                if (value == true)
                {
                    _Artikal = false;
                    _Izvjestaj = false;
                }
                _Partner = value;
            }
        }

        private static bool _Izvjestaj;

        public static bool Izvjestaj
        {
            get
            {
                return _Izvjestaj;
            }
            set
            {
                if (value == true)
                {
                    _Artikal = false;
                    _Partner = false;
                }
                _Izvjestaj = value;
            }
        }
    }
}
