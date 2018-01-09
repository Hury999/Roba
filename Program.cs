using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roba.DataBase_Objects;
using Roba.Global;
using Roba.Dodaj;

namespace Roba
{
   public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MyFunctions myfx = new MyFunctions();
            myfx.EqualGlobals();

            Application.Run(new Pocetna());
        }
    }
}
