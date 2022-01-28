using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Roba.LeftSide
{
    public partial class Kontakt : Form
    {
        public fx fx_delegate;
        MyFunctions myfx = new MyFunctions();

        public Kontakt()
        {
            InitializeComponent();
        }

        private void Kontakt_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.CenterToScreen();
            myfx.SetColors(new List<Control> { this });
            myfx.SetColors(btn_Posalji);
            label7.ForeColor = myfx.Get_Color_of_CurrentStyle();
            myfx.Set_Background_Image(btn_X, ControlType.X, false);
        }

        private void Kontakt_FormClosing(object sender, FormClosingEventArgs e)
        {
            fx_delegate();
        }

        private void btn_X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_X_MouseEnter(object sender, EventArgs e)
        {
            myfx.Set_Background_Image(btn_X, ControlType.X, true);
        }

        private void btn_X_MouseLeave(object sender, EventArgs e)
        {
            myfx.Set_Background_Image(btn_X, ControlType.X, false);
        }
         
        //Funkcija koja se poziva na click event od buttona Posalji
        //Prilikom kliktanja na button, poruka se salje na navedeni mail, sadrzaj poruke je iz textboxa
        private void btn_Posalji_Click(object sender, EventArgs e)
        {
            try
            {
                string mailBodyhtml = richTextBox1.Text;

                var msg = new MailMessage(txtBox_Adresa.Text, "Hury999@gmail.com", "Korisnik IESoftware", mailBodyhtml);
                msg.IsBodyHtml = true;
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential(txtBox_Adresa.Text, txtBox_Sifra.Text);
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
                MessageBox.Show("Poruka uspjesno poslana!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
