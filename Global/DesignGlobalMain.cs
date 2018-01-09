using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roba.Global
{
    public static class DesignGlobalMain
    {
        public static bool darkBlue;
        public static bool darkGreen;
        public static bool darkOrange;
        public static bool darkPurple;
        public static bool darkRed;
        public static bool darkYellow;
        public static bool liteBlue;
        public static bool liteGreen;
        public static bool liteOrange;
        public static bool litePurple;
        public static bool liteRed;
        public static bool liteYellow;
      
        public static bool Default;

        public static void ResetAll()
        {
            darkBlue = false;
            darkGreen = false;
            darkOrange = false;
            darkPurple = false;
            darkRed = false;
            darkYellow = false;

            liteBlue = false;
            liteGreen = false;
            liteOrange = false;
            litePurple = false;
            liteRed = false;
            liteYellow = false;

            Default = false;
        }

        public static void Sync()
        {
            DapperFunctions dapfx = new DapperFunctions();
            

        }
    }
}
