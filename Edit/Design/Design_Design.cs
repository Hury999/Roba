using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roba.Global;

namespace Roba.Edit.Design
{
    public enum PictureBoxes
    {
        BlueDark,
        BlueLight,
        GreenDark,
        GreenLight,
        OrangeDark,
        OrangeLight,
        PurpleDark,
        PurpleLight,
        RedLight,
        RedDark,
        YellowLight,
        YellowDark
    }


    partial class Form_Design : Form
    {
        public Pocetna FormPocetna_Design;

        private bool TogMove;
        private int X1 = 0;
        private int Y1 = 0;

        public Form_Design()
        {
            InitializeComponent();
        }

        MyFunctions myfx = new MyFunctions();

        private void GetStyle()
        {     
            myfx.SetColors(new List<Control> { this });
            myfx.Set_Background_Image(btn_X, ControlType.X, false);
        }

        private void SetPictures_Pictureboxes()
        {
            List<PictureBox> boxes = new List<PictureBox>();
            boxes.Add(pictureBox1);
            boxes.Add(pictureBox2);
            boxes.Add(pictureBox3);
            boxes.Add(pictureBox4);
            boxes.Add(pictureBox5);
            boxes.Add(pictureBox6);
            boxes.Add(pictureBox7);
            boxes.Add(pictureBox8);
            boxes.Add(pictureBox9);
            boxes.Add(pictureBox10);
            boxes.Add(pictureBox11);
            boxes.Add(pictureBox12);

            for (int i = 0; i < 12; i++)
            {
                switch (i)
                {
                    case (int)PictureBoxes.BlueDark:
                        boxes[i].BackgroundImage = Roba.Pictures.Design.BlueDark;
                        break;
                    case (int)PictureBoxes.BlueLight:
                        boxes[i].BackgroundImage = Roba.Pictures.Design.BlueLight;
                        break;

                    case (int)PictureBoxes.GreenDark:
                        boxes[i].BackgroundImage = Roba.Pictures.Design.GreenDark;
                        break;
                    case (int)PictureBoxes.GreenLight:
                        boxes[i].BackgroundImage = Roba.Pictures.Design.GreenLight;
                        break;

                    case (int)PictureBoxes.OrangeDark:
                        boxes[i].BackgroundImage = Roba.Pictures.Design.OrangeDark;
                        break;
                    case (int)PictureBoxes.OrangeLight:
                        boxes[i].BackgroundImage = Roba.Pictures.Design.OrangeLight;
                        break;

                    case (int)PictureBoxes.PurpleDark:
                        boxes[i].BackgroundImage = Roba.Pictures.Design.PurpleDark;
                        break;
                    case (int)PictureBoxes.PurpleLight:
                        boxes[i].BackgroundImage = Roba.Pictures.Design.PurpleLight;
                        break;

                    case (int)PictureBoxes.RedDark:
                        boxes[i].BackgroundImage = Roba.Pictures.Design.RedDark;
                        break;
                    case (int)PictureBoxes.RedLight:
                        boxes[i].BackgroundImage = Roba.Pictures.Design.RedLight;
                        break;

                    case (int)PictureBoxes.YellowDark:
                        boxes[i].BackgroundImage = Roba.Pictures.Design.YellowDark;
                        break;
                    case (int)PictureBoxes.YellowLight:
                        boxes[i].BackgroundImage = Roba.Pictures.Design.YellowLight;
                        break;
                }

            }
        }



        private void Design_Design_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.CenterToScreen();
            this.TopMost = true;
            this.Focus();
            SetPictures_Pictureboxes();

            FormPocetna_Design.Enabled = false;
            GetStyle();
        }

        private void Design_Design_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPocetna_Design.Enabled = true;
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

        private void Form_Design_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TogMove = true;
                X1 = e.X;
                Y1 = e.Y;
            }
        }

        private void Form_Design_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TogMove = false;
            }
        }

        private void Form_Design_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == true)
            {
                int X2 = 0;
                int Y2 = 0;

                X2 = e.X - X1;
                Y2 = e.Y - Y1;

                this.Location = new Point(this.Location.X + X2, this.Location.Y + Y2);
            }
        }

        private void chck_LiteBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_LiteBlue.Checked == true)
            {
                DesignGlobalMain.ResetAll();
                DesignGlobalMain.liteBlue = true;
                DapperFunctions dapfx = new DapperFunctions();
                dapfx.Update_DesignGlobal(PanelColor.liteBlue);
                FormPocetna_Design.GetStyle();
                GetStyle();
                FormPocetna_Design.dataGridView1.DefaultCellStyle.SelectionBackColor = myfx.Get_Color_of_CurrentStyle();
            }
        }

        private void chck_DarkBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_DarkBlue.Checked == true)
            {
                DesignGlobalMain.ResetAll();
                DesignGlobalMain.darkBlue = true;
                DapperFunctions dapfx = new DapperFunctions();
                dapfx.Update_DesignGlobal(PanelColor.darkBlue);
                FormPocetna_Design.GetStyle();
                GetStyle();
                FormPocetna_Design.dataGridView1.DefaultCellStyle.SelectionBackColor = myfx.Get_Color_of_CurrentStyle();
            }
        }

        private void chck_LiteGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_LiteGreen.Checked == true)
            {
                DesignGlobalMain.ResetAll();
                DesignGlobalMain.liteGreen = true;
                DapperFunctions dapfx = new DapperFunctions();
                dapfx.Update_DesignGlobal(PanelColor.liteGreen);
                FormPocetna_Design.GetStyle();
                GetStyle();
                FormPocetna_Design.dataGridView1.DefaultCellStyle.SelectionBackColor = myfx.Get_Color_of_CurrentStyle();
            }
        }

        private void chck_DarkGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_DarkGreen.Checked == true)
            {
                DesignGlobalMain.ResetAll();
                DesignGlobalMain.darkGreen = true;
                DapperFunctions dapfx = new DapperFunctions();
                dapfx.Update_DesignGlobal(PanelColor.darkGreen);
                FormPocetna_Design.GetStyle();
                GetStyle();
                FormPocetna_Design.dataGridView1.DefaultCellStyle.SelectionBackColor = myfx.Get_Color_of_CurrentStyle();
            }
        }

        private void chck_LiteOrange_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_LiteOrange.Checked == true)
            {
                DesignGlobalMain.ResetAll();
                DesignGlobalMain.liteOrange = true;
                DapperFunctions dapfx = new DapperFunctions();
                dapfx.Update_DesignGlobal(PanelColor.liteOrange);
                FormPocetna_Design.GetStyle();
                GetStyle();
                FormPocetna_Design.dataGridView1.DefaultCellStyle.SelectionBackColor = myfx.Get_Color_of_CurrentStyle();
            }
        }

        private void chck_DarkOrange_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_DarkOrange.Checked == true)
            {
                DesignGlobalMain.ResetAll();
                DesignGlobalMain.darkOrange = true;
                DapperFunctions dapfx = new DapperFunctions();
                dapfx.Update_DesignGlobal(PanelColor.darkOrange);
                FormPocetna_Design.GetStyle();
                GetStyle();
                FormPocetna_Design.dataGridView1.DefaultCellStyle.SelectionBackColor = myfx.Get_Color_of_CurrentStyle();
            }
        }

        private void chck_LitePurple_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_LitePurple.Checked == true)
            {
                DesignGlobalMain.ResetAll();
                DesignGlobalMain.litePurple = true;
                DapperFunctions dapfx = new DapperFunctions();
                dapfx.Update_DesignGlobal(PanelColor.litePurple);
                FormPocetna_Design.GetStyle();
                GetStyle();
                FormPocetna_Design.dataGridView1.DefaultCellStyle.SelectionBackColor = myfx.Get_Color_of_CurrentStyle();
            }
        }

        private void chck_DarkPurple_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_DarkPurple.Checked == true)
            {
                DesignGlobalMain.ResetAll();
                DesignGlobalMain.darkPurple = true;
                DapperFunctions dapfx = new DapperFunctions();
                dapfx.Update_DesignGlobal(PanelColor.darkPurple);
                FormPocetna_Design.GetStyle();
                GetStyle();
                FormPocetna_Design.dataGridView1.DefaultCellStyle.SelectionBackColor = myfx.Get_Color_of_CurrentStyle();
            }
        }

        private void chck_LiteRed_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_LiteRed.Checked == true)
            {
                DesignGlobalMain.ResetAll();
                DesignGlobalMain.liteRed = true;
                DapperFunctions dapfx = new DapperFunctions();
                dapfx.Update_DesignGlobal(PanelColor.liteRed);
                FormPocetna_Design.GetStyle();
                GetStyle();
                FormPocetna_Design.dataGridView1.DefaultCellStyle.SelectionBackColor = myfx.Get_Color_of_CurrentStyle();
            }
        }

        private void chck_DarkRed_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_DarkRed.Checked == true)
            {
                DesignGlobalMain.ResetAll();
                DesignGlobalMain.darkRed = true;
                DapperFunctions dapfx = new DapperFunctions();
                dapfx.Update_DesignGlobal(PanelColor.darkRed);
                FormPocetna_Design.GetStyle();
                GetStyle();
                FormPocetna_Design.dataGridView1.DefaultCellStyle.SelectionBackColor = myfx.Get_Color_of_CurrentStyle();
            }
        }

        private void chck_LiteYellow_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_LiteYellow.Checked == true)
            {
                DesignGlobalMain.ResetAll();
                DesignGlobalMain.liteYellow = true;
                DapperFunctions dapfx = new DapperFunctions();
                dapfx.Update_DesignGlobal(PanelColor.liteYellow);
                FormPocetna_Design.GetStyle();
                GetStyle();
                FormPocetna_Design.dataGridView1.DefaultCellStyle.SelectionBackColor = myfx.Get_Color_of_CurrentStyle();
            }
        }

        private void chck_DarkYellow_CheckedChanged(object sender, EventArgs e)
        {
            if (chck_DarkYellow.Checked == true)
            {
                DesignGlobalMain.ResetAll();
                DesignGlobalMain.darkYellow = true;
                DapperFunctions dapfx = new DapperFunctions();
                dapfx.Update_DesignGlobal(PanelColor.darkYellow);
                FormPocetna_Design.GetStyle();
                GetStyle();
                FormPocetna_Design.dataGridView1.DefaultCellStyle.SelectionBackColor = myfx.Get_Color_of_CurrentStyle();
            }
        }
    }
}
