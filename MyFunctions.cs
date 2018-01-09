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
using System.Data.SqlClient;
using Dapper;
using Roba.Global;
using Roba.DataBase_Objects;

namespace Roba
{
    public enum PanelColor
    {
        darkBlue,
        darkGreen,
        darkOrange,
        darkPurple,
        darkRed,
        darkYellow,
        liteBlue,
        liteGreen,
        liteOrange,
        litePurple,
        liteRed,
        liteYellow,
    }

    public enum ControlType
    {
        Logo,
        LogOut,
        LogoDown,
        Search,
        EditProfile,
        Maximize,
        Minimize,
        Ugao,
        X,
        btn_Izvjestaj,
        btn_Proizvod,
        btn_Partner
    }

    public enum TableType
    {
        Artikal,
        Izvjestaj,
        Partner
    }

    class MyFunctions
    {

        SqlConnection conn;

        public MyFunctions()
        {
            string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Roba.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection _conn = new SqlConnection(@"" + path);
            conn = _conn;
        }

        public void DataGridView_ColumsSort_Width(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].Width = dataGridView.Columns[i].HeaderText.Length * 7;
            }
        }

        public void DataGridView_Align(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        public void ResetId(string table)
        {
            int id = 0;

            id = conn.ExecuteScalar<int>("SELECT MAX(Id) FROM " + table);
            conn.Execute("DBCC CHECKIDENT (" + table + ", RESEED, @ID)", new { ID = id });
        }


        public void ResetId_To_Zero(string table)
        {
            int id = 0;
            conn.Execute("DBCC CHECKIDENT (" + table + ", RESEED, @ID)", new { ID = id });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="panels1">Set colors for these controls header like</param>
        /// <param name="panels2">Set colors for these controls sidebuttons like</param>
        /// <param name="panelsMainLike">Set colors for these controls main like</param>
        /// <param name="color"></param>

        private void ChangeColors(List<Control> panels1, List<Control> panels2, List<Control> panelsMainLike, PanelColor color)
        {
            //For panels1
            if (panels1 == null)
            {

            }

            else if (DesignGlobalMain.darkBlue || DesignGlobalMain.darkGreen || DesignGlobalMain.darkOrange || DesignGlobalMain.darkPurple || DesignGlobalMain.darkRed || DesignGlobalMain.darkYellow || DesignGlobalMain.Default)
            {
                for (int i = 0; i < panels1.Count; i++)
                {
                    panels1[i].BackColor = Color.FromArgb(27, 27, 27);
                }
            }

            else
            {
                for (int i = 0; i < panels1.Count; i++)
                {
                    panels1[i].BackColor = Color.FromArgb(215, 215, 215);
                }
            }

            //For panels2
            if (panels2 == null)
            {

            }

            else if (DesignGlobalMain.darkBlue || DesignGlobalMain.darkGreen || DesignGlobalMain.darkOrange || DesignGlobalMain.darkPurple || DesignGlobalMain.darkRed || DesignGlobalMain.darkYellow || DesignGlobalMain.Default)
            {
                for (int i = 0; i < panels2.Count; i++)
                {
                    panels2[i].BackColor = Color.FromArgb(20, 20, 20);
                }
            }

            else
            {
                for (int i = 0; i < panels2.Count; i++)
                {
                    panels2[i].BackColor = Color.FromArgb(146, 146, 146);
                }
            }

            //For panelsMainLike
            if (panelsMainLike == null)
            {

            }

            else if (DesignGlobalMain.darkBlue || DesignGlobalMain.darkGreen || DesignGlobalMain.darkOrange || DesignGlobalMain.darkPurple || DesignGlobalMain.darkRed || DesignGlobalMain.darkYellow || DesignGlobalMain.Default)
            {
                for (int i = 0; i < panelsMainLike.Count; i++)
                {
                    panelsMainLike[i].BackColor = Color.FromArgb(12, 12, 12);
                }
            }

            else
            {
                for (int i = 0; i < panelsMainLike.Count; i++)
                {
                    panelsMainLike[i].BackColor = Color.FromArgb(117, 117, 117);
                }
            }
        }

        private void ChangeColors(List<Control> panels1, List<Control> panelsMainLike, PanelColor color)
        {
            //For panels1
            if (panels1 == null)
            {

            }


            else if (DesignGlobalMain.darkBlue || DesignGlobalMain.darkGreen || DesignGlobalMain.darkOrange || DesignGlobalMain.darkPurple || DesignGlobalMain.darkRed || DesignGlobalMain.darkYellow || DesignGlobalMain.Default)
            {
                for (int i = 0; i < panels1.Count; i++)
                {
                    panels1[i].BackColor = Color.FromArgb(27, 27, 27);
                }
            }

            else
            {
                for (int i = 0; i < panels1.Count; i++)
                {
                    panels1[i].BackColor = Color.FromArgb(215, 215, 215);
                }
            }

            //For panels2
            if (panelsMainLike == null)
            {

            }


            else if (DesignGlobalMain.darkBlue || DesignGlobalMain.darkGreen || DesignGlobalMain.darkOrange || DesignGlobalMain.darkPurple || DesignGlobalMain.darkRed || DesignGlobalMain.darkYellow || DesignGlobalMain.Default)
            {
                for (int i = 0; i < panelsMainLike.Count; i++)
                {
                    panelsMainLike[i].BackColor = Color.FromArgb(10, 10, 10);
                }
            }

            else
            {
                for (int i = 0; i < panelsMainLike.Count; i++)
                {
                    panelsMainLike[i].BackColor = Color.FromArgb(190, 190, 190);
                }
            }
        }

        private void ChangeColors(List<Control> panels1, PanelColor color)
        {
            //For panels1
            if (DesignGlobalMain.darkBlue || DesignGlobalMain.darkGreen || DesignGlobalMain.darkOrange || DesignGlobalMain.darkPurple || DesignGlobalMain.darkRed || DesignGlobalMain.darkYellow || DesignGlobalMain.Default)
            {
                for (int i = 0; i < panels1.Count; i++)
                {
                    panels1[i].BackColor = Color.FromArgb(27, 27, 27);
                }
            }

            else
            {
                for (int i = 0; i < panels1.Count; i++)
                {
                    panels1[i].BackColor = Color.FromArgb(215, 215, 215);
                }
            }
        }

        private void ChangeColors(List<Button> buttons)
        {
            //For panels1
            if (DesignGlobalMain.darkBlue || DesignGlobalMain.darkGreen || DesignGlobalMain.darkOrange || DesignGlobalMain.darkPurple || DesignGlobalMain.darkRed || DesignGlobalMain.darkYellow || DesignGlobalMain.Default)
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].BackColor = Color.FromArgb(20, 20, 20);
                }
            }

            else
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].BackColor = Color.FromArgb(146, 146, 146);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control">Set color for control, basic button like(blue,red,green...)</param>

        public void SetColors(Control control)
        {
            if (DesignGlobalMain.darkBlue)
            {
                control.BackColor = Color.FromArgb(52, 152, 219);
            }
            else if (DesignGlobalMain.darkGreen)
            {
                control.BackColor = Color.FromArgb(46, 204, 113);
            }
            else if (DesignGlobalMain.darkOrange)
            {
                control.BackColor = Color.FromArgb(243, 156, 17);
            }
            else if (DesignGlobalMain.darkPurple)
            {
                control.BackColor = Color.FromArgb(155, 89, 182);
            }
            else if (DesignGlobalMain.darkRed)
            {
                control.BackColor = Color.FromArgb(231, 76, 60);
            }
            else if (DesignGlobalMain.darkYellow)
            {
                control.BackColor = Color.FromArgb(227, 239, 0);
            }

            //Lite
            else if (DesignGlobalMain.liteBlue)
            {
                control.BackColor = Color.FromArgb(52, 152, 219);
            }
            else if (DesignGlobalMain.liteGreen)
            {
                control.BackColor = Color.FromArgb(39, 174, 97);
            }
            else if (DesignGlobalMain.liteOrange)
            {
                control.BackColor = Color.FromArgb(243, 156, 17);
            }
            else if (DesignGlobalMain.litePurple)
            {
                control.BackColor = Color.FromArgb(155, 89, 182);
            }
            else if (DesignGlobalMain.liteRed)
            {
                control.BackColor = Color.FromArgb(231, 76, 60);
            }
            else if (DesignGlobalMain.liteYellow)
            {
                control.BackColor = Color.FromArgb(239, 254, 1);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="panels1">Set colors for these controls header like</param>
        /// <param name="panels2">Set colors for these controls sidebuttons like</param>
        /// <param name="panelsMainLike">Set colors for these controls main like</param>

        public void SetColors(List<Control> panels1, List<Control> panels2, List<Control> panelsMainLike)
        {
            if (DesignGlobalMain.darkBlue)
            {
                ChangeColors(panels1, panels2, panelsMainLike, PanelColor.darkBlue);
            }
            else if (DesignGlobalMain.darkGreen)
            {
                ChangeColors(panels1, panels2, panelsMainLike, PanelColor.darkGreen);
            }
            else if (DesignGlobalMain.darkOrange)
            {
                ChangeColors(panels1, panels2, panelsMainLike, PanelColor.darkOrange);
            }
            else if (DesignGlobalMain.darkPurple)
            {
                ChangeColors(panels1, panels2, panelsMainLike, PanelColor.darkPurple);
            }
            else if (DesignGlobalMain.darkRed)
            {
                ChangeColors(panels1, panels2, panelsMainLike, PanelColor.darkRed);
            }
            else if (DesignGlobalMain.darkYellow)
            {
                ChangeColors(panels1, panels2, panelsMainLike, PanelColor.darkYellow);
            }

            //Lite
            else if (DesignGlobalMain.liteBlue)
            {
                ChangeColors(panels1, panels2, panelsMainLike, PanelColor.liteBlue);
            }
            else if (DesignGlobalMain.liteGreen)
            {
                ChangeColors(panels1, panels2, panelsMainLike, PanelColor.liteGreen);
            }
            else if (DesignGlobalMain.liteOrange)
            {
                ChangeColors(panels1, panels2, panelsMainLike, PanelColor.liteOrange);
            }
            else if (DesignGlobalMain.litePurple)
            {
                ChangeColors(panels1, panels2, panelsMainLike, PanelColor.litePurple);
            }
            else if (DesignGlobalMain.liteRed)
            {
                ChangeColors(panels1, panels2, panelsMainLike, PanelColor.liteRed);
            }
            else if (DesignGlobalMain.liteYellow)
            {
                ChangeColors(panels1, panels2, panelsMainLike, PanelColor.liteYellow);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panels1">Set colors for these controls header like</param>
        /// <param name="panelsMainLike">Set colors for these controls main like</param>


        public void SetColors(List<Control> panels1, List<Control> panelsMainLike)
        {
            if (DesignGlobalMain.darkBlue)
            {
                ChangeColors(panels1, panelsMainLike, PanelColor.darkBlue);
            }
            else if (DesignGlobalMain.darkGreen)
            {
                ChangeColors(panels1, panelsMainLike, PanelColor.darkGreen);
            }
            else if (DesignGlobalMain.darkOrange)
            {
                ChangeColors(panels1, panelsMainLike, PanelColor.darkOrange);
            }
            else if (DesignGlobalMain.darkPurple)
            {
                ChangeColors(panels1, panelsMainLike, PanelColor.darkPurple);
            }
            else if (DesignGlobalMain.darkRed)
            {
                ChangeColors(panels1, panelsMainLike, PanelColor.darkRed);
            }
            else if (DesignGlobalMain.darkYellow)
            {
                ChangeColors(panels1, panelsMainLike, PanelColor.darkYellow);
            }

            //Lite
            else if (DesignGlobalMain.liteBlue)
            {
                ChangeColors(panels1, panelsMainLike, PanelColor.liteBlue);
            }
            else if (DesignGlobalMain.liteGreen)
            {
                ChangeColors(panels1, panelsMainLike, PanelColor.liteGreen);
            }
            else if (DesignGlobalMain.liteOrange)
            {
                ChangeColors(panels1, panelsMainLike, PanelColor.liteOrange);
            }
            else if (DesignGlobalMain.litePurple)
            {
                ChangeColors(panels1, panelsMainLike, PanelColor.litePurple);
            }
            else if (DesignGlobalMain.liteRed)
            {
                ChangeColors(panels1, panelsMainLike, PanelColor.liteRed);
            }
            else if (DesignGlobalMain.liteYellow)
            {
                ChangeColors(panels1, panelsMainLike, PanelColor.liteYellow);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panels1">Set colors for these controls header like</param>

        public void SetColors(List<Control> panels1)
        {
            if (DesignGlobalMain.darkBlue)
            {
                ChangeColors(panels1, PanelColor.darkBlue);
            }
            else if (DesignGlobalMain.darkGreen)
            {
                ChangeColors(panels1, PanelColor.darkGreen);
            }
            else if (DesignGlobalMain.darkOrange)
            {
                ChangeColors(panels1, PanelColor.darkOrange);
            }
            else if (DesignGlobalMain.darkPurple)
            {
                ChangeColors(panels1, PanelColor.darkPurple);
            }
            else if (DesignGlobalMain.darkRed)
            {
                ChangeColors(panels1, PanelColor.darkRed);
            }
            else if (DesignGlobalMain.darkYellow)
            {
                ChangeColors(panels1, PanelColor.darkYellow);
            }

            //Lite
            else if (DesignGlobalMain.liteBlue)
            {
                ChangeColors(panels1, PanelColor.liteBlue);
            }
            else if (DesignGlobalMain.liteGreen)
            {
                ChangeColors(panels1, PanelColor.liteGreen);
            }
            else if (DesignGlobalMain.liteOrange)
            {
                ChangeColors(panels1, PanelColor.liteOrange);
            }
            else if (DesignGlobalMain.litePurple)
            {
                ChangeColors(panels1, PanelColor.litePurple);
            }
            else if (DesignGlobalMain.liteRed)
            {
                ChangeColors(panels1, PanelColor.liteRed);
            }
            else if (DesignGlobalMain.liteYellow)
            {
                ChangeColors(panels1, PanelColor.liteYellow);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttons">Set colors sidebuttons like</param>

        public void SetColors(List<Button> buttons)
        {
            if (DesignGlobalMain.darkBlue)
            {
                ChangeColors(buttons);
            }
            else if (DesignGlobalMain.darkGreen)
            {
                ChangeColors(buttons);
            }
            else if (DesignGlobalMain.darkOrange)
            {
                ChangeColors(buttons);
            }
            else if (DesignGlobalMain.darkPurple)
            {
                ChangeColors(buttons);
            }
            else if (DesignGlobalMain.darkRed)
            {
                ChangeColors(buttons);
            }
            else if (DesignGlobalMain.darkYellow)
            {
                ChangeColors(buttons);
            }

            //Lite
            else if (DesignGlobalMain.liteBlue)
            {
                ChangeColors(buttons);
            }
            else if (DesignGlobalMain.liteGreen)
            {
                ChangeColors(buttons);
            }
            else if (DesignGlobalMain.liteOrange)
            {
                ChangeColors(buttons);
            }
            else if (DesignGlobalMain.litePurple)
            {
                ChangeColors(buttons);
            }
            else if (DesignGlobalMain.liteRed)
            {
                ChangeColors(buttons);
            }
            else if (DesignGlobalMain.liteYellow)
            {
                ChangeColors(buttons);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttons"></param>
        /// <param name="col1">Set color to control of dark theme</param>
        /// <param name="col2">Set color to control of lite theme</param>

        public void SetColors(List<Button> buttons, Color col1, Color col2)
        {
            //For panels1
            if (DesignGlobalMain.darkBlue || DesignGlobalMain.darkGreen || DesignGlobalMain.darkOrange || DesignGlobalMain.darkPurple || DesignGlobalMain.darkRed || DesignGlobalMain.darkYellow || DesignGlobalMain.Default)
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].BackColor = col1;
                }
            }

            else
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].BackColor = col2;
                }
            }
        }

        public void EqualGlobals()
        {
            DapperFunctions dapfx = new DapperFunctions();

            DesignGlobal design = dapfx.GetAll_Designs();

            DesignGlobalMain.darkBlue = design.darkBlue;
            DesignGlobalMain.darkGreen = design.darkGreen;
            DesignGlobalMain.darkOrange = design.darkOrange;
            DesignGlobalMain.darkPurple = design.darkPurple;
            DesignGlobalMain.darkRed = design.darkRed;
            DesignGlobalMain.darkYellow = design.darkYellow;

            DesignGlobalMain.liteBlue = design.liteBlue;
            DesignGlobalMain.liteGreen = design.liteGreen;
            DesignGlobalMain.liteOrange = design.liteOrange;
            DesignGlobalMain.litePurple = design.litePurple;
            DesignGlobalMain.liteRed = design.liteRed;
            DesignGlobalMain.liteYellow = design.liteYellow;

            DesignGlobalMain.Default = design.Defaultt;
        }

        public void Set_Background_Image(Control control, ControlType controlType, bool hover)
        {
            control.BackgroundImageLayout = ImageLayout.Zoom;

            if (hover)
            {
                if (controlType == ControlType.X)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xhoverdarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xhoverdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xhoverdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xhoverdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xhoverdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xhoverdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xhoverliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xhoverlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xhoverliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xhoverlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xhoverlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xhoverliteyellow;
                    }

                }
                else if (controlType == ControlType.Maximize)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizehoverdarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizehoverdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizehoverdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizehoverdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizehoverdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizehoverdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizehoverliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizehoverlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizehoverliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizehoverlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizehoverlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizehoverliteyellow;
                    }
                }
                else if (controlType == ControlType.Minimize)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizehoverdarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizehoverdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizehoverdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizehoverdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizehoverdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizehoverdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizehoverliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizehoverlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizehoverliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizehoverlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizehoverlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizehoverliteyellow;
                    }
                }
                else if (controlType == ControlType.Search)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchhoverdarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchhoverdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchhoverdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchhoverdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchhoverdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchhoverdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchhoverliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchhoverlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchhoverliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchhoverlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchhoverlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchhoverliteyellow;
                    }

                }
                else if (controlType == ControlType.LogOut)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logouthoverdarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logouthoverdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logouthoverdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logouthoverdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logouthoverdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logouthoverdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logouthoverliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logouthoverlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logouthoverliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logouthoverlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logouthoverlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logouthoverliteyellow;
                    }

                }
                else if (controlType == ControlType.EditProfile)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilehovedarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilehoverdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilehoverdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilehoverdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilehoverdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilehoverdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilehoverliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilehoverlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilehoverliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilehoverlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilehoverlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilehoverliteyellow;
                    }
                }
                else if (controlType == ControlType.btn_Izvjestaj)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajhoverdarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajhoverdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajhoverdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajhoverdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajhoverdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajhoverdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajhoverliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajhoverlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajhoverliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajhoverlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajhoverlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajhoverliteyellow;
                    }
                }
                else if (controlType == ControlType.btn_Partner)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerhoverdarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerhoverdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerhoverdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerhoverdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerhoverdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerhoverdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerhoverliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerhoverlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerhoverliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerhoverlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerhoverlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerhoverliteyellow;
                    }
                }
                else if (controlType == ControlType.btn_Proizvod)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodhoverdarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodhoverdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodhoverdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodhoverdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodhoverdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodhoverdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodhoverliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodhoverlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodhoverliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodhoverlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodhoverlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodhoverliteyellow;
                    }
                }
            }

            if (!hover)
            {
                if (controlType == ControlType.EditProfile)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofiledarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofiledarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofiledarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofiledarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofiledarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofiledarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofileliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilelitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofileliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilelitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofilelitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.EditProfile.editprofileliteyellow;
                    }
                }
                else if (controlType == ControlType.Logo)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Logo.logodarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Logo.logodarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Logo.logodarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Logo.logodarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Logo.logodarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Logo.logodarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Logo.logoliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Logo.logolitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Logo.logoliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Logo.logolitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Logo.logolitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Logo.logoliteyellow;
                    }

                }
                else if (controlType == ControlType.LogoDown)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.LogoDown.logodonjidarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.LogoDown.logodonjidarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.LogoDown.logodonjidarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.LogoDown.logodonjidarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.LogoDown.logodonjidarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.LogoDown.logodonjidarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.LogoDown.logodonjiliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.LogoDown.logodonjilitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.LogoDown.logodonjiliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.LogoDown.logodonjilitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.LogoDown.logodonjilitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.LogoDown.logodonjiliteyellow;
                    }

                }
                else if (controlType == ControlType.LogOut)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logoutDarkBlue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logoutdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logoutdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logoutdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logoutdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logoutdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logoutliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logoutlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logoutliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logoutlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logoutlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.LogOut.logoutliteyellow;
                    }

                }
                else if (controlType == ControlType.Search)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchdarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Search.searchliteyellow;
                    }

                }
                else if (controlType == ControlType.Maximize)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizedarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizedarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizedarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizedarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizedarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizedarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizeliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizelitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizeliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizelitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizelitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Maximize.maximizeliteyellow;
                    }
                }
                else if (controlType == ControlType.Minimize)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizedarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizedarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizedarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizedarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizedarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizedarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizeliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizelitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizeliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizelitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizelitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Minimize.minimizeliteyellow;
                    }
                }
                else if (controlType == ControlType.X)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xdarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.X.xliteyellow;
                    }
                }
                else if (controlType == ControlType.Ugao)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Ugao.lijeviugaodarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Ugao.lijeviugaodarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Ugao.lijeviugaodarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Ugao.lijeviugaodarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Ugao.lijeviugaodarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Ugao.lijeviugaodarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Ugao.lijeviugaoliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Ugao.lijeviugaolitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Ugao.lijeviugaoliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Ugao.lijeviugaolitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Ugao.lijeviugaolitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Ugao.lijeviugaoliteyellow;
                    }
                }
                else if (controlType == ControlType.btn_Izvjestaj)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajdarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Izvjestaj.izvjestajliteyellow;
                    }
                }
                else if (controlType == ControlType.btn_Partner)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerdarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerdarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerdarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerdarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerdarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerdarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Partner.partnerliteyellow;
                    }
                }
                else if (controlType == ControlType.btn_Proizvod)
                {
                    if (DesignGlobalMain.darkBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvoddarkblue;
                    }
                    else if (DesignGlobalMain.darkGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvoddarkgreen;
                    }
                    else if (DesignGlobalMain.darkOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvoddarkorange;
                    }
                    else if (DesignGlobalMain.darkPurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvoddarkpurple;
                    }
                    else if (DesignGlobalMain.darkRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvoddarkred;
                    }
                    else if (DesignGlobalMain.darkYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvoddarkyellow;
                    }
                    //Lite
                    else if (DesignGlobalMain.liteBlue)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodliteblue;
                    }
                    else if (DesignGlobalMain.liteGreen)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodlitegreen;
                    }
                    else if (DesignGlobalMain.liteOrange)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodliteorange;
                    }
                    else if (DesignGlobalMain.litePurple)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodlitepurple;
                    }
                    else if (DesignGlobalMain.liteRed)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodlitered;
                    }
                    else if (DesignGlobalMain.liteYellow)
                    {
                        control.BackgroundImage = Roba.Pictures.Proizvod.proizvodliteyellow;
                    }
                }
            }
        }


        //For button dobrodosao and kontaktirajte nas

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Get colors of current style of app.(red,blue.green)</returns>
        public Color Get_Color_of_CurrentStyle()
        {
            if (DesignGlobalMain.darkBlue)
            {
                return Color.FromArgb(52, 152, 219);
            }
            else if (DesignGlobalMain.darkGreen)
            {
                return Color.FromArgb(46, 204, 113);
            }
            else if (DesignGlobalMain.darkOrange)
            {
                return Color.FromArgb(243, 156, 17);
            }
            else if (DesignGlobalMain.darkPurple)
            {
                return Color.FromArgb(155, 89, 182);
            }
            else if (DesignGlobalMain.darkRed)
            {
                return Color.FromArgb(231, 76, 60);
            }
            else if (DesignGlobalMain.darkYellow)
            {
                return Color.FromArgb(227, 239, 0);
            }

            //Lite
            else if (DesignGlobalMain.liteBlue)
            {
                return Color.FromArgb(52, 152, 219);
            }
            else if (DesignGlobalMain.liteGreen)
            {
                return Color.FromArgb(39, 174, 97);
            }
            else if (DesignGlobalMain.liteOrange)
            {
                return Color.FromArgb(243, 156, 17);
            }
            else if (DesignGlobalMain.litePurple)
            {
                return Color.FromArgb(155, 89, 182);
            }
            else if (DesignGlobalMain.liteRed)
            {
                return Color.FromArgb(231, 76, 60);
            }
            else if (DesignGlobalMain.liteYellow)
            {
                return Color.FromArgb(239, 254, 1);
            }

            return Color.FromArgb(0, 0, 0);
        }

        public void SetFolders(Pocetna pocetna, bool Maximized)
        {
            DapperFunctions dapfx = new DapperFunctions();

            this.RemoveAll<CustomButton>(new CustomButton(pocetna), pocetna.Folders);

            int x_row = 0;
            int y_row = 0;
            int MaxInRow = 9;

            List<Tables_Izvjestaji> Generatedtables = dapfx.GetGeneratedTablesName_Izvjestaj();

            for (int i = 0; i < dapfx.Get_NumberOfFolders(); i++)
            {
                if (i >= MaxInRow)
                {
                    y_row += 1;
                    x_row = 0;

                    if (Maximized)
                    {
                        MaxInRow += 14;
                    }
                    else
                    {
                        MaxInRow += 9;
                    }
                }

                pocetna.Folders.Add(new CustomButton(pocetna));
                pocetna.Folders[i].Visible = true;
                pocetna.Folders[i].Size = new System.Drawing.Size(90, 84);
                pocetna.Folders[i].Text = Generatedtables[i].Date.ToString();
                pocetna.Folders[i].Text = pocetna.Folders[i].Text.Remove(10, pocetna.Folders[i].Text.Length - 10);
                pocetna.Folders[i].TextAlign = ContentAlignment.BottomCenter;
                pocetna.Folders[i].Font = new Font("Elkwood", 14);
                pocetna.Folders[i].ForeColor = Color.FromArgb(55, 55, 55);
                pocetna.Folders[i].Parent = pocetna.panel7;
                pocetna.panel7.Controls.Add(pocetna.Folders[i]);
                if (Maximized)
                {
                    pocetna.Folders[i].Location = new Point(220 + ((pocetna.Folders[i].Width + 10) * x_row), 20 + ((pocetna.Folders[i].Height + 70) * y_row));
                    MaxInRow = 14;
                }
                else
                {
                    pocetna.Folders[i].Location = new Point(10 + ((pocetna.Folders[i].Width + 10) * x_row), 20 + ((pocetna.Folders[i].Height + 70) * y_row));
                    MaxInRow = 9;
                }
                pocetna.Folders[i].BackgroundImage = Roba.Pictures.Folders.Folder;
                pocetna.Folders[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                pocetna.Folders[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                pocetna.Folders[i].FlatAppearance.BorderSize = 0;
                pocetna.Folders[i].FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                pocetna.Folders[i].FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                pocetna.Folders[i].UseVisualStyleBackColor = true;
                pocetna.Folders[i].BringToFront();
                pocetna.Folders[i].MouseEnter += new EventHandler(CustomButton.Mouse_Enter);
                pocetna.Folders[i].MouseLeave += new EventHandler(CustomButton.Mouse_Leave);
                pocetna.Folders[i].TableName_Izvjestaj = Generatedtables[i].Tablename.Remove(0, 9);
                pocetna.Folders[i].MouseClick += new MouseEventHandler(pocetna.Folders[i].OpenSpecificIzvjestaj);
                pocetna.Folders[i].MouseDown += new MouseEventHandler(pocetna.Folders[i].DeleteSpecificIzvjestaj);

                x_row += 1;
            }
        }

        public void RemoveAll<T>(T item, List<T> list)
        {
            while (list.Contains(item))
            {
                list.Remove(item);
            }
        }
    }
}
