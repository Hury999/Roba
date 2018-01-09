using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roba
{
    public class CustomButton : Button
    {
        DapperFunctions dapfx = new DapperFunctions();
        MyFunctions myfx = new MyFunctions();
        Pocetna pocetna;
        public string TableName_Izvjestaj { get; set; }

        public CustomButton(Pocetna _pocetna)
        {
            pocetna = _pocetna;
        }

        public void OpenSpecificIzvjestaj(object sender, MouseEventArgs e)
        {
            pocetna.dataGridView1.DataSource = dapfx.GetAll_Izvjestaj(TableName_Izvjestaj);
            pocetna.dataGridView1.Visible = true;
            myfx.DataGridView_Align(pocetna.dataGridView1);

            for (int i = 0; i < dapfx.Get_NumberOfFolders(); i++)
            {
                pocetna.Folders[i].Visible = false;
            }
        }

        public void DeleteSpecificIzvjestaj(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dapfx.DeleteGeneratedTableName_Izvjestaj("Izvjestaj" + TableName_Izvjestaj);
                dapfx.Set_NumberOfFolders(dapfx.Get_NumberOfFolders() - 1);
                this.Dispose();
                if (pocetna.maximized)
                {
                    myfx.SetFolders(pocetna, true);
                }
                else
                {
                    myfx.SetFolders(pocetna, false);
                }
            }
        }

        

        internal static void Mouse_Enter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.BackgroundImage = Roba.Pictures.Folders.Folder_hover;
        }

        internal static void Mouse_Leave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.BackgroundImage = Roba.Pictures.Folders.Folder;
        }
    }
}
