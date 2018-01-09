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
using Roba.Dodaj;
using Roba.LeftSide;
using Roba.Edit;
using Roba.Read_Forms;
using Roba.DataBase_Objects;
using Roba.Global;
using System.Drawing.Printing;

namespace Roba
{
    public delegate void fx();
    public delegate void fx_Design();

    public partial class Pocetna : Form
    {
        public fx fx_delegate;
        MyFunctions myfx = new MyFunctions();
        DapperFunctions dapfx = new DapperFunctions();
        public List<CustomButton> Folders;

        public Pocetna()
        {
            InitializeComponent();
        }

        Edit_Menu edit_menu;

        private bool TogMove;
        private int X1 = 0;
        private int Y1 = 0;

        public void GetStyle()
        {
            MyFunctions myfx = new MyFunctions();

            List<Control> list1 = new List<Control>();
            list1.Add(panel4);
            list1.Add(panel6);
            list1.Add(logoIE);
            list1.Add(panel2);

            List<Control> list2 = new List<Control>();
            list2.Add(btn_Proizvodi);
            list2.Add(btn_Partneri);
            list2.Add(btn_Izvjestaj);


            List<Control> list3 = new List<Control>();
            list3.Add(this);
            list3.Add(panel7);
            list3.Add(btn_Dobrodosao);


            myfx.SetColors(list1, list2, list3);

            myfx.Set_Background_Image(panel10, ControlType.Logo, false);
            myfx.Set_Background_Image(panel8, ControlType.LogoDown, false);
            myfx.Set_Background_Image(btn_Dodaj_Proizvod, ControlType.btn_Proizvod, false);
            myfx.Set_Background_Image(btn_Dodaj_Partnera, ControlType.btn_Partner, false);
            myfx.Set_Background_Image(btn_Pregled_Izvjestaja, ControlType.btn_Izvjestaj, false);
            myfx.Set_Background_Image(btn_X, ControlType.X, false);
            myfx.Set_Background_Image(btn_Search, ControlType.Search, false);
            myfx.Set_Background_Image(btn_Edit_Profile, ControlType.EditProfile, false);
            myfx.Set_Background_Image(btn_LogOut, ControlType.LogOut, false);
            myfx.Set_Background_Image(btn_Maximi, ControlType.Maximize, false);
            myfx.Set_Background_Image(btn_Minimiz, ControlType.Minimize, false);

            btn_Proizvodi.FlatAppearance.MouseDownBackColor = myfx.Get_Color_of_CurrentStyle();
            btn_Izvjestaj.FlatAppearance.MouseDownBackColor = myfx.Get_Color_of_CurrentStyle();
            btn_Partneri.FlatAppearance.MouseDownBackColor = myfx.Get_Color_of_CurrentStyle();


            btn_Proizvodi.FlatAppearance.MouseOverBackColor = myfx.Get_Color_of_CurrentStyle();
            btn_Izvjestaj.FlatAppearance.MouseOverBackColor = myfx.Get_Color_of_CurrentStyle();
            btn_Partneri.FlatAppearance.MouseOverBackColor = myfx.Get_Color_of_CurrentStyle();

            btn_Kupi.BackColor = myfx.Get_Color_of_CurrentStyle();
        }
        private void Pocetna_Load(object sender, EventArgs e)
        {
            this.Icon = Roba.Icon.ikonica;
            lbl_Print.Visible = false;
            lbl_Print.Location = new Point(btn_Kupi.Location.X, btn_Kupi.Location.Y - 20);

            Folders = new List<CustomButton>(dapfx.Get_NumberOfFolders());
            dataGridView1.Visible = false;
            btn_Kupi.Visible = false;
            txtBox_Kolicina.Visible = false;
            lbl_Kolicina.Visible = false;

            this.CenterToScreen();
            dataGridView1.Location = new Point(197, 120);
            dataGridView1.Location = new Point(dataGridView1.Location.X - 200, dataGridView1.Location.Y);
            dataGridView1.DefaultCellStyle.SelectionBackColor = myfx.Get_Color_of_CurrentStyle();

            if (DesignGlobalMain.darkBlue || DesignGlobalMain.darkGreen || DesignGlobalMain.darkOrange || DesignGlobalMain.darkPurple || DesignGlobalMain.darkRed || DesignGlobalMain.darkYellow)
            {
                btn_X.FlatAppearance.BorderColor = Color.FromArgb(27, 27, 27);
            }
            else
            {
                btn_X.FlatAppearance.BorderColor = Color.FromArgb(215, 215, 215);
            }

            GetStyle();

            FileStream sr = new FileStream(Directory.GetCurrentDirectory() + @"\Res\Logo.jpg", FileMode.Open);
            Image map = Image.FromStream(sr);
            sr.Close();
            panel10.BackgroundImage = map;
        }

        //
        //Panels for moving form on dekstop
        //

        bool _MouseDown;
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TogMove = true;
                X1 = e.X;
                Y1 = e.Y;

                _MouseDown = true;
            }
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TogMove = false;

                if (Cursor.Position.Y == 0)
                {
                    Pocetna_Maximize();
                }
            }
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == true)
            {
                int X2 = 0;
                int Y2 = 0;

                X2 = e.X - X1;
                Y2 = e.Y - Y1;

                this.Location = new Point(this.Location.X + X2, this.Location.Y + Y2);

                if (_MouseDown == true && maximized == true)
                {
                    this.Refresh();
                    int x = (Cursor.Position.X * 100) / Screen.PrimaryScreen.WorkingArea.Width;

                    int _x = (1071 * x) / 100;

                    Pocetna_Minimize();
                    this.Location = new Point(this.Location.X + _x, this.Location.Y);
                }
            }
        }
        //
        //Panels for moving form on dekstop
        //

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TogMove = true;
                X1 = e.X;
                Y1 = e.Y;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TogMove = false;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
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

        private void btn_Power_Hover_MouseUp(object sender, MouseEventArgs e)
        {
            fx_delegate();
            this.Close();
        }
        //
        //Buttons of Search,Home,Log off
        //

        //
        //Buttons of Kontaktirajte nas
        //
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            lbl_Kontaktirajte_nas.ForeColor = myfx.Get_Color_of_CurrentStyle();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            lbl_Kontaktirajte_nas.ForeColor = Color.White;
        }
        //
        //Buttons of Kontaktirajte nas
        //

        private Size minimized_dataGridView_Size;

        private void btn_dodaj_novog_partnera_hover_MouseUp(object sender, MouseEventArgs e)
        {
            this.Enabled = false;

            DodajNovogPartnera frm_dodajnovogpartnera = new DodajNovogPartnera();
            frm_dodajnovogpartnera.Show();
        }

        private void lbl_Kontaktirajte_nas_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            Kontakt frm_kontakt = new Kontakt();
            frm_kontakt.Show();
            frm_kontakt.fx_delegate = new fx(Pocetna_Enable);
        }

        private void btn_Proizvodi_Click(object sender, EventArgs e)
        {
            lbl_Print.Visible = true;
            lbl_Print.Location = new Point(btn_Kupi.Location.X, btn_Kupi.Location.Y - 20);

            Izvjestaj_Clicked = false;

            ChangeVisibility_Folders(false);

            //Mark which table you currently read
            CurrentEditGrid.Artikal = true;


            DapperFunctions dapfx = new DapperFunctions();
            MyFunctions myfx = new MyFunctions();

            myfx.SetColors(btn_Proizvodi);

            //Reset colors of other buttons
            myfx.SetColors(new List<Button> { btn_Izvjestaj });
            myfx.SetColors(new List<Button> { btn_Partneri });

            dataGridView1.Visible = true;
            btn_Kupi.Visible = true;
            btn_Kupi.Text = "KUPI";

            txtBox_Kolicina.Visible = true;
            lbl_Kolicina.Visible = true;

            dataGridView1.DataSource = dapfx.GetAll_Artikal();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Detalji"].Visible = false;
            dataGridView1.ReadOnly = false;

            myfx.DataGridView_Align(dataGridView1);
        }

        bool Izvjestaj_Clicked;
        private void btn_Izvjestaj_Click(object sender, EventArgs e)
        {
            Izvjestaj_Clicked = true;
            if (maximized)
            {
                myfx.SetFolders(this, true);
            }
            else
            {
                myfx.SetFolders(this, false);
            }
            btn_Dodaj_Partnera.Visible = false;
            btn_Dodaj_Proizvod.Visible = false;
            btn_Pregled_Izvjestaja.Visible = false;
            btn_Kupi.Visible = false;
            txtBox_Kolicina.Visible = false;
            lbl_Kolicina.Visible = false;
            lbl_Print.Visible = false;
            lbl_Print.Location = new Point(btn_Kupi.Location.X, btn_Kupi.Location.Y - 20);

            dataGridView1.Visible = false;
            dataGridView1.DataSource = null;

            myfx.SetColors(btn_Izvjestaj);
            myfx.SetColors(new List<Button> { btn_Proizvodi });
            myfx.SetColors(new List<Button> { btn_Partneri });

        }

        private void btn_Partneri_Click(object sender, EventArgs e)
        {
            lbl_Print.Visible = true;
            lbl_Print.Location = new Point(lbl_Print.Location.X + 85, lbl_Print.Location.Y + 50);

            Izvjestaj_Clicked = false;

            ChangeVisibility_Folders(false);

            CurrentEditGrid.Partner = true;

            btn_Kupi.Visible = false;
            txtBox_Kolicina.Visible = false;
            lbl_Kolicina.Visible = false;

            DapperFunctions dapfx = new DapperFunctions();
            MyFunctions myfx = new MyFunctions();

            myfx.SetColors(btn_Partneri);

            //Reset colors of other buttons
            myfx.SetColors(new List<Button> { btn_Izvjestaj });
            myfx.SetColors(new List<Button> { btn_Proizvodi });


            dataGridView1.Visible = true;

            dataGridView1.DataSource = dapfx.GetAll_Partner();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.ReadOnly = false;

            myfx.DataGridView_Align(dataGridView1);
        }

        private void btn_Home_Hover_MouseUp(object sender, MouseEventArgs e)
        {
            this.Enabled = false;

            EditProfile editprofile = new EditProfile();
            editprofile.Show();
        }

        private void btn_Dobrodosao_MouseEnter(object sender, EventArgs e)
        {
            btn_Dobrodosao.ForeColor = Color.Gray;
        }

        private void btn_Dobrodosao_MouseLeave(object sender, EventArgs e)
        {
            btn_Dobrodosao.ForeColor = Color.White;
        }

        private void btn_Dobrodosao_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Dobrodosao.ForeColor = Color.White;

        }

        private void btn_Dobrodosao_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Dobrodosao.ForeColor = Color.White;
        }

        private void lbl_Edit_Click(object sender, EventArgs e)
        {
            lbl_Edit.ForeColor = Color.White;

            edit_menu = new Edit_Menu();
            edit_menu.FormPocetna_Menu = this;
            edit_menu.Show();
            edit_menu.TopMost = true;

            if (lbl_Edit.Location == new Point(164, 94))
            {
                edit_menu.Location = lbl_Edit.PointToScreen(new Point(lbl_Edit.Location.X - 170, lbl_Edit.Location.Y));
            }
            else
            {
                edit_menu.Location = lbl_Edit.PointToScreen(new Point(lbl_Edit.Location.X, lbl_Edit.Location.Y));
            }

            if (this.maximized == true)
            {
                edit_menu.Location = new Point(edit_menu.Location.X - 50, edit_menu.Location.Y - 75);
                edit_menu.lbl_Strelica.Location = new Point(edit_menu.lbl_Strelica.Location.X + 40, edit_menu.lbl_Strelica.Location.Y);
            }
            else
            {
                edit_menu.Location = new Point(edit_menu.Location.X, edit_menu.Location.Y - 75);
            }
        }

        private void lbl_Edit_MouseEnter(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            lbl_Edit.ForeColor = myfx.Get_Color_of_CurrentStyle();
        }


        private void btn_Dobrodosao_Click(object sender, EventArgs e)
        {
            Izvjestaj_Clicked = false;

            ChangeVisibility_Folders(false);

            dataGridView1.Visible = false;
            btn_Kupi.Visible = false;
            txtBox_Kolicina.Visible = false;
            lbl_Kolicina.Visible = false;
            lbl_Print.Visible = false;

            btn_Dodaj_Partnera.Visible = true;
            btn_Dodaj_Proizvod.Visible = true;
            btn_Pregled_Izvjestaja.Visible = true;

            MyFunctions myfx = new MyFunctions();
            //Reset colors of other buttons
            myfx.SetColors(new List<Button> { btn_Proizvodi });
            myfx.SetColors(new List<Button> { btn_Izvjestaj });
            myfx.SetColors(new List<Button> { btn_Partneri });
        }



        private void Pocetna_Disable()
        {
            this.Enabled = false;
        }

        private void Pocetna_Enable()
        {
            this.Enabled = true;
        }



        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (CurrentEditGrid.Artikal == true)
                {

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Selected)
                        {
                            Artikal artikal = new Artikal()
                            {
                                Id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value),
                                Proizvod = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value),
                                Proizvodac = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value),
                                Stanje = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value),
                                Cijena = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value),
                                BarKod = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value),
                                Detalji = Convert.ToString(dataGridView1.Rows[i].Cells[6].Value)
                            };

                            Detalji detalji = new Detalji(dataGridView1.Rows[i].Cells[6].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), artikal);
                            detalji.delegate_fx = new fx(Reset_dataGridView);
                            detalji.Show();
                        }
                    }
                }
            }
        }

        private void Reset_dataGridView()
        {
            if (CurrentEditGrid.Artikal == true)
            {
                DapperFunctions dapfx = new DapperFunctions();

                dataGridView1.DataSource = dapfx.GetAll_Artikal();
            }

            else if (CurrentEditGrid.Partner == true)
            {
                DapperFunctions dapfx = new DapperFunctions();

                dataGridView1.DataSource = dapfx.GetAll_Partner();
            }
        }

        public void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (CurrentEditGrid.Artikal == true)
            {
                Artikal artikal = new Artikal();
                artikal.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                artikal.Proizvod = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                artikal.Proizvodac = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                artikal.Stanje = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                artikal.Cijena = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                artikal.BarKod = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                artikal.Detalji = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value);

                DapperFunctions dapFX = new DapperFunctions();
                dapFX.Update_Artikal(artikal);

            }

            else if (CurrentEditGrid.Partner == true)
            {
                Partner partner = new Partner();
                partner.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                partner.Ime = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                partner.Firma = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                partner.Tel = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                partner.Email = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                partner.Adresa = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                partner.Mjesto = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value);

                DapperFunctions dapFX = new DapperFunctions();
                dapFX.Update_Partner(partner);

            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (CurrentEditGrid.Artikal == true)
                {
                    DapperFunctions dapfx = new DapperFunctions();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        dapfx.Delete_Artikal(Convert.ToInt32(dataGridView1.SelectedRows[i].Cells[0].Value));
                    }

                    List<Artikal> artikli = new List<Artikal>();
                    artikli = dapfx.GetAll_Artikal();

                    dataGridView1.DataSource = artikli;
                }

                else if (CurrentEditGrid.Partner == true)
                {
                    DapperFunctions dapfx = new DapperFunctions();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        dapfx.Delete_Partner(Convert.ToInt32(dataGridView1.SelectedRows[i].Cells[0].Value));
                    }

                    List<Partner> partneri = new List<Partner>();
                    partneri = dapfx.GetAll_Partner();

                    dataGridView1.DataSource = partneri;
                }

                else if (CurrentEditGrid.Izvjestaj == true)
                {
                    DapperFunctions dapfx = new DapperFunctions();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        dapfx.Delete_Izvjestaj(Convert.ToInt32(dataGridView1.SelectedRows[i].Cells[0].Value));
                    }

                    List<Izvjestaj> izvjestaji = new List<Izvjestaj>();
                    izvjestaji = dapfx.GetAll_Izvjestaj("Izvjestaj");

                    dataGridView1.DataSource = izvjestaji;
                }
            }
        }

        private void btn_Dodaj_Proizvod_Click(object sender, EventArgs e)
        {
            DodajNoviProizvod dodaj_proizvod = new DodajNoviProizvod();
            dodaj_proizvod.FormPocetna_Proizvod = this;
            dodaj_proizvod.Show();
        }



        private void btn_Maximize_Click(object sender, EventArgs e)
        {

        }

        public bool maximized;

        private void Pocetna_Minimize()
        {
            this.WindowState = FormWindowState.Normal;
            maximized = false;

            panel7.Width = 873;

            btn_Pregled_Izvjestaja.Location = new Point(357, panel7.Height / 2);

            btn_Dodaj_Proizvod.Location = new Point(549, panel7.Height / 2);

            btn_Dodaj_Partnera.Location = new Point(165, panel7.Height / 2);

            dataGridView1.Location = logoIE.Location;
            dataGridView1.Location = new Point(dataGridView1.Location.X, dataGridView1.Location.Y + logoIE.Height);

            dataGridView1.Size = new Size(panel7.Size.Width, panel7.Size.Height);

            MyFunctions myFx = new MyFunctions();
            myFx.DataGridView_Align(dataGridView1);

        }

        private void Pocetna_Maximize()
        {

            if (!maximized)
            {
                maximized = true;

                minimized_dataGridView_Size = dataGridView1.Size;

                this.WindowState = FormWindowState.Maximized;
                panel7.Width += Screen.PrimaryScreen.WorkingArea.Width - panel7.Width;

                btn_Pregled_Izvjestaja.Location = new Point(panel7.Width / 2, (panel7.Height / 2) - logoIE.Height);

                btn_Dodaj_Partnera.Location = new Point((panel7.Width / 2) - (btn_Dodaj_Proizvod.Width + 60), (panel7.Height / 2) - logoIE.Height);

                btn_Dodaj_Proizvod.Location = new Point((panel7.Width / 2) + (btn_Dodaj_Partnera.Width + 60), (panel7.Height / 2) - logoIE.Height);

                dataGridView1.Location = panel7.Location;
                dataGridView1.Location = new Point(dataGridView1.Location.X + logoIE.Width, panel7.Location.Y);
                dataGridView1.Size = new Size(panel7.Size.Width - 200, panel7.Size.Height);

                MyFunctions myFx = new MyFunctions();
                myFx.DataGridView_Align(dataGridView1);

                btn_Kupi.Location = new Point(panel7.Width / 2, panel7.Height / 2);
                btn_Kupi.Location = new Point(btn_Kupi.Location.X + (btn_Kupi.Location.X - (btn_Kupi.Width + 20)), btn_Kupi.Location.Y + (btn_Kupi.Location.Y - (btn_Kupi.Height + 20)));

                txtBox_Kolicina.Location = new Point(panel7.Width / 2, panel7.Height / 2);
                txtBox_Kolicina.Location = new Point(txtBox_Kolicina.Location.X + (txtBox_Kolicina.Location.X - (btn_Kupi.Width + 90)), txtBox_Kolicina.Location.Y + (txtBox_Kolicina.Location.Y - (btn_Kupi.Height + 15)));
                lbl_Kolicina.Location = new Point(panel7.Width - (btn_Kupi.Width + txtBox_Kolicina.Width + 100), panel7.Height - (btn_Kupi.Height + 10));

                if (Izvjestaj_Clicked)
                {
                    myfx.SetFolders(this, true);
                }

                lbl_Print.Location = new Point(btn_Kupi.Location.X, btn_Kupi.Location.Y - 20);
            }

            else if (maximized)
            {

                this.WindowState = FormWindowState.Normal;
                maximized = false;

                panel7.Width = 873;
                btn_Pregled_Izvjestaja.Location = new Point(362, 189);

                btn_Dodaj_Proizvod.Location = new Point(362 + 186, 189);

                btn_Dodaj_Partnera.Location = new Point(362 - 186, 189);

                dataGridView1.Location = panel7.Location;
                dataGridView1.Location = new Point(panel7.Location.X - logoIE.Width + 5, panel7.Location.Y);

                dataGridView1.Size = new Size(panel7.Size.Width, panel7.Size.Height);

                MyFunctions myFx = new MyFunctions();
                myFx.DataGridView_Align(dataGridView1);

                btn_Kupi.Location = new Point(737, 569);
                txtBox_Kolicina.Location = new Point(667, 574);
                lbl_Kolicina.Location = new Point(594, 580);

                if (Izvjestaj_Clicked)
                {
                    myfx.SetFolders(this, false);
                }

                lbl_Print.Location = new Point(btn_Kupi.Location.X, btn_Kupi.Location.Y - 20);
            }
        }

        private void btn_Maximize_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Maximized;

                Pocetna_Maximize();
            }
        }


        private void btn_Dodaj_Partnera_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            DodajNovogPartnera frm_dodajnovogpartnera = new DodajNovogPartnera();
            frm_dodajnovogpartnera.FormPocetna_Partner = this;
            frm_dodajnovogpartnera.Show();
        }

        private void btn_Dodaj_Partnera_MouseEnter(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_Dodaj_Partnera, ControlType.btn_Partner, true);
        }

        private void btn_Dodaj_Partnera_MouseLeave(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_Dodaj_Partnera, ControlType.btn_Partner, false);
        }

        private void btn_PregledIzvjestaja_MouseEnter(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_Pregled_Izvjestaja, ControlType.btn_Izvjestaj, true);
        }

        private void btn_PregledIzvjestaja_MouseLeave(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_Pregled_Izvjestaja, ControlType.btn_Izvjestaj, false);
        }

        private void btn_Dodaj_Proizvod_MouseEnter(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_Dodaj_Proizvod, ControlType.btn_Proizvod, true);
        }

        private void btn_Dodaj_Proizvod_MouseLeave(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_Dodaj_Proizvod, ControlType.btn_Proizvod, false);
        }

        private void btn_Search_MouseEnter(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_Search, ControlType.Search, true);
        }

        private void btn_Search_MouseLeave(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_Search, ControlType.Search, false);
        }

        private void btn_Edit_Profile_MouseEnter(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_Edit_Profile, ControlType.EditProfile, true);
        }

        private void btn_Edit_Profile_MouseLeave(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_Edit_Profile, ControlType.EditProfile, false);
        }

        private void btn_LogOut_MouseEnter(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_LogOut, ControlType.LogOut, true);
        }

        private void btn_LogOut_MouseLeave(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_LogOut, ControlType.LogOut, false);
        }

        private void btn_X_MouseEnter(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_X, ControlType.X, true);
        }

        private void btn_X_MouseLeave(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
            myfx.Set_Background_Image(btn_X, ControlType.X, false);
        }

        private void btn_Maximize_MouseEnter(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
        }

        private void btn_Maximize_MouseLeave(object sender, EventArgs e)
        {
            MyFunctions myfx = new MyFunctions();
        }

        private void btn_Minimize_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btn_Minimize_MouseLeave(object sender, EventArgs e)
        {
        }

        private void btn_Edit_Profile_Click(object sender, EventArgs e)
        {
            EditProfile edit_profile = new EditProfile();
            edit_profile.MainForm = this;
            edit_profile.Show();
        }

        private void btn_X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbl_Edit_MouseLeave_1(object sender, EventArgs e)
        {
            lbl_Edit.ForeColor = Color.White;
        }

        private void lbl_Edit_MouseEnter_1(object sender, EventArgs e)
        {
            lbl_Edit.ForeColor = myfx.Get_Color_of_CurrentStyle();
        }

        private void lbl_Edit_MouseLeave(object sender, EventArgs e)
        {
            lbl_Edit.ForeColor = Color.White;
        }

        private void btn_Maximize_Click_2(object sender, EventArgs e)
        {
            Pocetna_Maximize();
        }

        private void btn_Minimizee_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Maximi_MouseEnter(object sender, EventArgs e)
        {
            myfx.Set_Background_Image(btn_Maximi, ControlType.Maximize, true);
        }

        private void btn_Maximi_MouseLeave(object sender, EventArgs e)
        {
            myfx.Set_Background_Image(btn_Maximi, ControlType.Maximize, false);
        }

        private void btn_Minimiz_MouseEnter(object sender, EventArgs e)
        {
            myfx.Set_Background_Image(btn_Minimiz, ControlType.Minimize, true);
        }

        private void btn_Minimiz_MouseLeave(object sender, EventArgs e)
        {
            myfx.Set_Background_Image(btn_Minimiz, ControlType.Minimize, false);
        }

        private void btn_Maximi_Click(object sender, EventArgs e)
        {
            Pocetna_Maximize();
        }

        private void btn_Minimiz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Kupi_Click(object sender, EventArgs e)
        {
            DapperFunctions dapfx = new DapperFunctions();


            int Kolicina_Kupi = Convert.ToInt32(txtBox_Kolicina.Text);
            int Nova_Kolicina = 0;
            int SveukupnoKomada = 0;

            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                Nova_Kolicina = Convert.ToInt32(dataGridView1.SelectedRows[i].Cells[3].Value) - Kolicina_Kupi;

                if (Nova_Kolicina < 0)
                {
                    Nova_Kolicina = 0;
                }
                dataGridView1.SelectedRows[i].Cells[3].Value = Nova_Kolicina;

                Izvjestaj izvjestaj = new Izvjestaj();
                izvjestaj.Ime = dataGridView1.SelectedRows[i].Cells[1].Value.ToString();
                izvjestaj.Cijena = Convert.ToDecimal(dataGridView1.SelectedRows[i].Cells[4].Value);
                izvjestaj.Komada = Convert.ToInt32(txtBox_Kolicina.Text);
                izvjestaj.Date = DateTime.Now;

                List<Izvjestaj> izvjestaji = dapfx.GetAll_Izvjestaj("");

                foreach (Izvjestaj izvjestajMember in izvjestaji)
                {
                    if (izvjestajMember.Ime == izvjestaj.Ime)
                    {
                        SveukupnoKomada += izvjestajMember.Komada;
                    }
                }

                SveukupnoKomada += Convert.ToInt32(txtBox_Kolicina.Text);

                izvjestaj.Sveukupno = Convert.ToDecimal(dataGridView1.SelectedRows[i].Cells[4].Value) * SveukupnoKomada;
                izvjestaj.Ukupno = SveukupnoKomada;

                SveukupnoKomada = 0;
                dapfx.Insert_Izvjestaj(izvjestaj);
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CurrentEditGrid.Artikal)
            {
                dataGridView1.DataSource = dapfx.Get_AllSorted_Artikal(dataGridView1.Columns[e.ColumnIndex].HeaderText);
            }
            else if (CurrentEditGrid.Izvjestaj)
            {
                dataGridView1.DataSource = dapfx.Get_AllSorted_Izvjestaj(dataGridView1.Columns[e.ColumnIndex].HeaderText);
            }
            else
            {
                dataGridView1.DataSource = dapfx.Get_AllSorted_Partner(dataGridView1.Columns[e.ColumnIndex].HeaderText);
            }

            ColorSelectedColumn(e.ColumnIndex);
            DataGridView_SelectedColumn = e.ColumnIndex;
        }

        private void btn_PregledIzvjestaja_Click(object sender, EventArgs e)
        {
            CurrentEditGrid.Izvjestaj = true;

            dataGridView1.Visible = true;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dapfx.GetAll_Izvjestaj();
            myfx.DataGridView_Align(dataGridView1);

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = dataGridView1.Columns[2].Width - 20;
            dataGridView1.Columns[2].Width = dataGridView1.Columns[2].Width - 20;
            dataGridView1.Columns[3].Width = dataGridView1.Columns[3].Width - 50;
            dataGridView1.Columns[4].Width = dataGridView1.Columns[4].Width - 60;
            dataGridView1.Columns[5].Width = dataGridView1.Columns[5].Width - 60;
        }

        private void ChangeVisibility_Folders(bool bol)
        {
            if (bol)
            {
                for (int i = 0; i < dapfx.Get_NumberOfFolders(); i++)
                {
                    if (Folders.Count > 0)
                    {
                        Folders[i].Visible = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < dapfx.Get_NumberOfFolders(); i++)
                {
                    if (Folders.Count > 0)
                    {
                        Folders[i].Visible = false;
                    }
                }
            }
        }

        int DataGridView_SelectedColumn;
        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (txtBox_Search.Visible)
            {
                txtBox_Search.Visible = false;
                lbl_Edit.Location = new Point(164, 94);
            }
            else
            {
                txtBox_Search.Visible = true;
                lbl_Edit.Location = new Point(8, 94);
            }
        }

        private void txtBox_Search_TextChanged(object sender, EventArgs e)
        {
            if (CurrentEditGrid.Artikal)
            {
                switch (DataGridView_SelectedColumn)
                {
                    case (int)SelectedColumnArtikal.Proizvod:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Proizvod", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnArtikal.Proizvodac:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Proizvodac", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnArtikal.Stanje:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Stanje", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnArtikal.Cijena:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Cijena", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnArtikal.BarKod:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("BarKod", txtBox_Search.Text);
                        break;
                }
            }

            else if (CurrentEditGrid.Izvjestaj)
            {
                switch (DataGridView_SelectedColumn)
                {
                    case (int)SelectedColumnIzvjestaj.Ime:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Ime", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnIzvjestaj.Cijena:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Cijena", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnIzvjestaj.Komada:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Komada", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnIzvjestaj.Ukupno:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Ukupno", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnIzvjestaj.SveUkupno:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("SveUkupno", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnIzvjestaj.Date:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Date", txtBox_Search.Text);
                        break;
                }
            }

            else if (CurrentEditGrid.Partner)
            {
                switch (DataGridView_SelectedColumn)
                {
                    case (int)SelectedColumnPartner.Ime:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Ime", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnPartner.Firma:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Firma", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnPartner.Tel:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Tel", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnPartner.Email:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Email", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnPartner.Adresa:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Adresa", txtBox_Search.Text);
                        break;
                    case (int)SelectedColumnPartner.Mjesto:
                        dataGridView1.DataSource = dapfx.GetAll_Artikal("Mjesto", txtBox_Search.Text);
                        break;
                }
            }
        }

        private void ColorSelectedColumn(int ColumnIndex)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[ColumnIndex].Selected = true;
            }

            if (dataGridView1.Rows[1].Cells[1].Selected != true)
            {
                dataGridView1.Rows[0].Cells[1].Selected = false;
            }
        }

        private void lbl_Print_MouseEnter(object sender, EventArgs e)
        {
            lbl_Print.ForeColor = myfx.Get_Color_of_CurrentStyle();
        }

        private void lbl_Print_MouseLeave(object sender, EventArgs e)
        {
            lbl_Print.ForeColor = Color.Black;
        }

        Bitmap bmp;
        private void lbl_Print_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printDialog = new PrintPreviewDialog();
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.DocumentName = "IE";
            printDocument1.PrintPage += PrintDocument1_PrintPage;

            printDocument1.DocumentName = "Test Page Print";
            Bitmap bmp2 = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp2, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.RowCount * 45));
            bmp = new Bitmap(bmp2, new Size(bmp2.Size.Width - 50, bmp2.Size.Height - 50));
            printDialog.Document = printDocument1;
            printDialog.ShowDialog();

        }
        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, new Point(-10, 0));
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            txtBox_Search.Visible = false;
            lbl_Edit.Location = new Point(164, 94);
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            txtBox_Search.Visible = false;
            lbl_Edit.Location = new Point(164, 94);
        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            txtBox_Search.Visible = false;
            lbl_Edit.Location = new Point(164, 94);
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            txtBox_Search.Visible = false;
            lbl_Edit.Location = new Point(164, 94);
        }

        private void logoIE_Click(object sender, EventArgs e)
        {
            txtBox_Search.Visible = false;
            lbl_Edit.Location = new Point(164, 94);
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            txtBox_Search.Visible = false;
            lbl_Edit.Location = new Point(164, 94);
        }

        private void dataGridView1_VisibleChanged(object sender, EventArgs e)
        {
            if(maximized)
            {
                //dataGridView1.Location = logoIE.Location;
                //dataGridView1.Location = new Point(dataGridView1.Location.X, dataGridView1.Location.Y + logoIE.Height);
            }
            else
            {
                dataGridView1.Location = panel7.Location;
                dataGridView1.Location = new Point(panel7.Location.X - logoIE.Width + 5, panel7.Location.Y);
            }
        }

        private void Pocetna_SizeChanged(object sender, EventArgs e)
        {
            if (maximized)
            {
                dataGridView1.Location = logoIE.Location;
                dataGridView1.Location = new Point(dataGridView1.Location.X, dataGridView1.Location.Y + logoIE.Height);
            }
            else
            {
                dataGridView1.Location = panel7.Location;
                dataGridView1.Location = new Point(panel7.Location.X - logoIE.Width + 5, panel7.Location.Y);
            }
        }
    }

    enum SelectedColumnArtikal
    {
        Id,
        Proizvod,
        Proizvodac,
        Stanje,
        Cijena,
        BarKod,
    }

    enum SelectedColumnIzvjestaj
    {
        Id,
        Ime,
        Cijena,
        Komada,
        Ukupno,
        SveUkupno,
        Date
    }

    enum SelectedColumnPartner
    {
        Id,
        Ime,
        Firma,
        Tel,
        Email,
        Adresa,
        Mjesto
    }
}

