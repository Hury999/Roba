using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Shell32;
using System.Drawing.Text;

namespace Roba
{
    partial class Login : Form
    {

        private readonly MyFunctions myfx = new MyFunctions();
        private readonly DapperFunctions dapfx = new DapperFunctions();
        //
        //Moving Form_Login on dekstop
        //

        private bool TogMove;
        private int X1;
        private int Y1;

        public Login()
        {
            InitializeComponent();
        }



        private void Login_Load(object sender, EventArgs e)
        {
            this.Icon = Roba.Icon.ikonica;
            InstalledFontCollection FontCollection = new InstalledFontCollection();
            bool fontExist = new bool();
            foreach (FontFamily FontFamily in FontCollection.Families)
            {
                if (FontFamily.Name == "Elkwood")
                {
                    fontExist = true;
                    break;
                }
            }

            if (!fontExist)
            {
                Shell shell = new Shell();
                Folder Fontfolder = shell.NameSpace(0x14);
                Fontfolder.CopyHere(Directory.GetCurrentDirectory() + @"\Fonts\Elkwood-Free.ttf");
                Fontfolder.CopyHere(Directory.GetCurrentDirectory() + @"\Fonts\Elkwood-Free.otf");
            }

            this.CenterToScreen();
            this.ShowInTaskbar = true;

            List<Control> list1 = new List<Control>();
            list1.Add(panel1);
            list1.Add(pictureBox1);
            list1.Add(this);

            myfx.SetColors(list1);
            myfx.SetColors(button1);
            myfx.Set_Background_Image(btn_X, ControlType.X, false);

            myfx.Set_Background_Image(pictureBox1, ControlType.Logo, false);
            myfx.Set_Background_Image(pictureBox2, ControlType.LogoDown, false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DapperFunctions dapfx = new DapperFunctions();

            if (txtBox_Username.Text == dapfx.GetUsername() && txtBox_Password.Text == dapfx.GetPassword())
            {
                Pocetna pocetna = new Pocetna();
                pocetna.Show();
                pocetna.fx_delegate = Login_Show;
                Hide();
            }
            else
            {
                MessageBox.Show("Pogrešno unešeni podaci!");
            }
        }

        private void Login_Show()
        {
            Show();
        }


        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;

            X1 = e.X;
            Y1 = e.Y;
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                var X2 = e.X - X1;
                var Y2 = e.Y - Y1;

                Location = new Point(Location.X + X2, Location.Y + Y2);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                var X2 = e.X - X1;
                var Y2 = e.Y - Y1;

                Location = new Point(Location.X + X2, Location.Y + Y2);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;

            X1 = e.X;
            Y1 = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                var X2 = e.X - X1;
                var Y2 = e.Y - Y1;

                Location = new Point(Location.X + X2, Location.Y + Y2);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;

            X1 = e.X;
            Y1 = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;

            X1 = e.X;
            Y1 = e.Y;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                var X2 = e.X - X1;
                var Y2 = e.Y - Y1;

                Location = new Point(Location.X + X2, Location.Y + Y2);
            }
        }

        private void Login_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                CenterToScreen();

                List<Control> list1 = new List<Control>();
                list1.Add(panel1);
                list1.Add(pictureBox1);
                list1.Add(this);

                myfx.SetColors(list1);
                myfx.SetColors(button1);

                myfx.Set_Background_Image(pictureBox1, ControlType.Logo, false);
                myfx.Set_Background_Image(pictureBox2, ControlType.LogoDown, false);
            }
        }

        private void Login_SizeChanged(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Location = new Point(this.Location.X - ((Screen.PrimaryScreen.WorkingArea.Width / 2) / 2), this.Location.Y - ((Screen.PrimaryScreen.WorkingArea.Height / 2) / 2));
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

        private void CheckTime_Tick(object sender, EventArgs e)
        {
            if (dapfx.Get_FirstRun() == true)
            {
                dapfx.Set_ProgramDate(DateTime.Now);
                dapfx.Set_FirstRun(false);
            }

            if (dapfx.Get_ProgramDate().Date != DateTime.Now.Date)
            {
                int brFoldera = dapfx.Get_NumberOfFolders();
                dapfx.Set_NumberOfFolders(brFoldera + 1);
                dapfx.CreateTable_Izvjestaj((brFoldera + 1).ToString());
                dapfx.InsertGeneratedTableName_Izvjestaj("Izvjestaj" + (brFoldera + 1).ToString(), dapfx.Get_ProgramDate());
                dapfx.DeleteAll_Izvjestaj();
                dapfx.Set_ProgramDate(DateTime.Now);
            }
        }
    }
}