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

    public partial class DodajNoviProizvod : Form
    {
        MyFunctions myfx = new MyFunctions();
        public Pocetna FormPocetna_Proizvod = new Pocetna();


        public DodajNoviProizvod()
        {
            InitializeComponent();
        }

        private void btn_X_MouseEnter(object sender, EventArgs e)
        {

        }

        //Event tipke za izlazak iz programa
        private void btn_X_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPocetna_Proizvod.Enabled = true;
            FormPocetna_Proizvod.Focus();
        }


        //Event za loadanje forme DodajNoviProizvod
        private void DodajNoviProizvod_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false; //Da se ne pojavljuje forma u taskbaru
            this.CenterToScreen(); //Centriranje forme na ekranu
            FormPocetna_Proizvod.Enabled = false; //Iskljucivanje(sakrivanje) parent forme

            myfx.SetColors(btn_Dodaj);
            myfx.SetColors(new List<Control> { this });
            lbl_DodajNoviProizvod.ForeColor = myfx.Get_Color_of_CurrentStyle();
            myfx.Set_Background_Image(btn_X, ControlType.X, false);
        }

        private void DodajNoviProizvod_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_Dodaj_Click(object sender, EventArgs e)
        {
            if (txtBox_BarKod.Text != "" && txtBox_Cijena.Text != "" && txtBox_Detalji.Text != "" && txtBox_Proizvod.Text != "" && txtBox_Proizvodac.Text != "" && txtBox_Stanje.Text != "")
            {
                MyFunctions myFx = new MyFunctions();
                myFx.ResetId("Artikal");

                Artikal artikal = new Artikal()
                {
                    Proizvod = txtBox_Proizvod.Text,
                    Proizvodac = txtBox_Proizvodac.Text,

                    Stanje = Convert.ToInt32(txtBox_Stanje.Text),
                    Cijena = Convert.ToDecimal(txtBox_Cijena.Text),
                    BarKod = Convert.ToInt32(txtBox_BarKod.Text),
                    Detalji = txtBox_Detalji.Text
                };

                DapperFunctions dapfx = new DapperFunctions();
                dapfx.Insert_Artikal(artikal);
            }

            else
            {
                MessageBox.Show("Molimo vas popunite sva polja!");
            }
        }


        private void btn_X_MouseEnter_1(object sender, EventArgs e)
        {
            myfx.Set_Background_Image(btn_X, ControlType.X, true);
        }

        private void btn_X_MouseLeave(object sender, EventArgs e)
        {
            myfx.Set_Background_Image(btn_X, ControlType.X, false);
        }
    }
}
