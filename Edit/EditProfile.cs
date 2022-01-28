using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Roba.Pictures;
using System.Resources;

namespace Roba.Edit
{
    public partial class EditProfile : Form
    {

        public Pocetna MainForm;

        public EditProfile()
        {
            InitializeComponent();
        }

        MyFunctions myfx = new MyFunctions();

        //Prilikom loadanja forme EditProfile izvrsi setovanje dizajna forme
        private void EditProfile_Load(object sender, EventArgs e)
        {
            FileStream streamRead = new FileStream(Directory.GetCurrentDirectory() + @"\Res\Logo.jpg",FileMode.Open);

            panel4.BackgroundImage = Image.FromStream(streamRead);

            streamRead.Dispose();

            this.ShowInTaskbar = false;

            MainForm.Enabled = false;
            this.CenterToScreen();

            myfx.SetColors(new List<Control> { this });
            myfx.SetColors(btn_Spremi);
            myfx.Set_Background_Image(btn_X, ControlType.X, false);
            lbl_UrediProfil.ForeColor = myfx.Get_Color_of_CurrentStyle();

        }

        private void EditProfile_FormClosing(object sender, FormClosingEventArgs e)
        {

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
            MainForm.Enabled = true;
            MainForm.Focus();
        }

        private void btn_Spremi_Click(object sender, EventArgs e)
        {
            DapperFunctions dapfx = new DapperFunctions();

            if (txtBox_TrenutniPassword.Text == dapfx.GetPassword() && txtBox_TrenutniUsername.Text == dapfx.GetUsername())
            {
                try
                {
                    dapfx.UpdatePassword(txtBox_NoviPassword.Text);
                    dapfx.UpdateUsername(txtBox_NoviUsername.Text);
                    MessageBox.Show("Korisničko ime i šifra su uspješno promjenjeni!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            else
            {
                MessageBox.Show("Pogrešno uneseni trenutno korisničko ime ili šifra!");
            }
        }

        private void lbl_Browse_MouseEnter(object sender, EventArgs e)
        {
            lbl_Browse.ForeColor = myfx.Get_Color_of_CurrentStyle();
        }

        private void lbl_Browse_MouseLeave(object sender, EventArgs e)
        {
            lbl_Browse.ForeColor = Color.White;
        }
        
        //Napravi browsing tipku za sliku tj. omoguci custom biranje slike programa za korisnika
        private void lbl_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string filetoopen = fd.FileName;
                Image image = Image.FromFile(filetoopen);

                Bitmap NewMap = (Bitmap)image;

                MainForm.panel10.BackgroundImage = image;
                panel4.BackgroundImage = NewMap;

                File.Copy(filetoopen, Directory.GetCurrentDirectory() + @"\Res\Logo.jpg",true);
            }
        }
    }
}
