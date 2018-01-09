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

namespace Roba.Dodaj
{
    public partial class DodajNovogPartnera : Form
    {

        MyFunctions myfx = new MyFunctions();
        public Pocetna FormPocetna_Partner;

        public DodajNovogPartnera()
        {
            InitializeComponent();
        }


        private void btn_X_Click_1(object sender, EventArgs e)
        {
            this.Close();
            FormPocetna_Partner.Enabled = true;
            FormPocetna_Partner.Focus();
        }

        private void DodajNovogPartnera_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.CenterToParent();
            this.CenterToScreen();

            FormPocetna_Partner.Enabled = false;

            myfx.SetColors(new List<Control> {this});
            myfx.SetColors(btn_Dodaj);
            myfx.Set_Background_Image(btn_X, ControlType.X, false);

            lbl_DodajNovogPartnera.ForeColor = myfx.Get_Color_of_CurrentStyle();
        }

        private void btn_X_MouseEnter(object sender, EventArgs e)
        {
            myfx.Set_Background_Image(btn_X, ControlType.X, true);
        }

        private void btn_X_MouseLeave(object sender, EventArgs e)
        {
            myfx.Set_Background_Image(btn_X, ControlType.X, false);
        }

        private void btn_Dodaj_Click(object sender, EventArgs e)
        {
            MyFunctions myFx = new MyFunctions();
            myFx.ResetId("Partner");

            Partner partner = new Partner()
            {
                Ime = txtBox_Ime.Text,
                Firma = txtBox_Firma.Text,
                Tel = txtBox_Tel.Text,
                Email = txtBox_Email.Text,
                Adresa = txtBox_Adresa.Text,
                Mjesto = txtBox_Mjesto.Text
            };

            DapperFunctions dapfx = new DapperFunctions();

            try
            {
                dapfx.Insert_Partner(partner);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
