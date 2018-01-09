using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roba.Edit.Design;

namespace Roba.Edit
{
    public partial class Edit_Menu : Form
    {
        public Pocetna FormPocetna_Menu;


        public Edit_Menu()
        {
            InitializeComponent();
        }

        private void Edit_Menu_Leave(object sender, EventArgs e)
        {

        }

        private void btn_Design_Click(object sender, EventArgs e)
        {
            Form_Design design = new Form_Design();
            design.FormPocetna_Design = FormPocetna_Menu;
            design.Show();
            this.Close();
        }

        private void Edit_Menu_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;

            MyFunctions myfx = new MyFunctions();
            this.Deactivate += new EventHandler(this_Deactivate);

            myfx.SetColors(new List<Control> { this });
            myfx.SetColors(btn_Design);
            lbl_Edit.ForeColor = myfx.Get_Color_of_CurrentStyle();
            lbl_Strelica.ForeColor = myfx.Get_Color_of_CurrentStyle();
        }

        private void this_Deactivate(object sender,EventArgs e)
        {
            this.Close();
        }
    }
}
