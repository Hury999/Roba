using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roba.DataBase_Objects;

namespace Roba.Read_Forms
{
    public partial class Detalji : Form
    {
        public fx delegate_fx;

        private string detalji;
        private string invokeProizvod;
        Artikal artikal;
        MyFunctions myfx = new MyFunctions();

        public Detalji(string _detalji, string _invokeProizvod, Artikal _artikal)
        {
            InitializeComponent();

            detalji = _detalji;
            invokeProizvod = _invokeProizvod;
            artikal = _artikal;
        }

        private void btn_X_MouseEnter(object sender, EventArgs e)
        {
            myfx.Set_Background_Image(btn_X, ControlType.X, true);
        }

        private void btn_X_MouseLeave(object sender, EventArgs e)
        {
            myfx.Set_Background_Image(btn_X, ControlType.X, false);
        }

        private void btn_X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Detalji_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;

            this.CenterToScreen();

            lbl_Detalji_Za.Text = "DETALJI ZA: " + invokeProizvod;
            txtBox_Detalji.Text = detalji;

            myfx.SetColors(btn_Dodaj);
            myfx.SetColors(new List<Control> { this });
            lbl_Detalji_Za.ForeColor = myfx.Get_Color_of_CurrentStyle();
            myfx.Set_Background_Image(btn_X, ControlType.X, false);
        }

        private void btn_Dodaj_Click(object sender, EventArgs e)
        {
            DapperFunctions dapFX = new DapperFunctions();
            artikal.Detalji = txtBox_Detalji.Text;
            dapFX.Update_Artikal(artikal);
            delegate_fx();      
        }
    }
}
