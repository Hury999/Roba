using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Roba.DataBase_Objects;
using System.Data.SqlClient;

//Ova kalsa sluzi za dohvatanje podataka preko SQL query-a. 

namespace Roba
{
    class DapperFunctions
    {
        public SqlConnection conn;

        //Konstruktor koji locira lokaciju baze podataka na lokalnom racunaru.
        public DapperFunctions()
        {
            string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Roba.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection _conn = new SqlConnection(@"" + path);
            conn = _conn;
        }

        //Artikal
 
        //Funkcija koja dohvaca artikle iz baze i smjesta ih u objekte Artikal.
        #region Artikal
        public List<Artikal> GetAll_Artikal()
        {

            List<Artikal> artikli = conn.Query<Artikal>("SELECT * FROM Artikal").ToList();

            return artikli;
        }

        
        public List<Artikal> GetAll_Artikal(string WhichColumn, string Value)
        {

            List<Artikal> artikli = conn.Query<Artikal>("SELECT * FROM Artikal WHERE " + WhichColumn + " LIKE '" + Value + "%'").ToList();

            return artikli;
        }

        public void Insert_Artikal(Artikal artikal)
        {
            conn.Execute("INSERT INTO Artikal (Proizvod,Proizvodac,Stanje,Cijena,BarKod,Detalji) VALUES (@Proizvod,@Proizvodac,@Stanje,@Cijena,@BarKod,@Detalji)", artikal);
        }

        public void Update_Artikal(Artikal artikal)
        {
            conn.Execute("UPDATE Artikal SET Proizvod = @Proizvod, Proizvodac = @Proizvodac, Stanje = @Stanje, Cijena = @Cijena, BarKod = @BarKod, Detalji = @Detalji WHERE Id = @Id", artikal);
        }

        public void Delete_Artikal(int id)
        {
            conn.Execute("DELETE FROM Artikal WHERE Id=@ID", new { ID = id });
        }

        bool ArtikalTwoWay;
        public List<Artikal> Get_AllSorted_Artikal(string ColumnName)
        {
            if (ArtikalTwoWay)
            {
                List<Artikal> artikli = conn.Query<Artikal>("SELECT * FROM Artikal ORDER BY " + ColumnName).ToList();
                ArtikalTwoWay = false;
                return artikli;
            }
            else
            {
                List<Artikal> artikli = conn.Query<Artikal>("SELECT * FROM Artikal ORDER BY " + ColumnName + " DESC").ToList();
                ArtikalTwoWay = true;
                return artikli;
            }
        }

        #endregion Artikal

        #region Partner
        public List<Partner> GetAll_Partner()
        {

            List<Partner> partneri = conn.Query<Partner>("SELECT * FROM Partner").ToList();

            return partneri;
        }

        public void Insert_Partner(Partner partner)
        {
            conn.Execute("INSERT INTO Partner (Ime,Firma,Tel,Email,Adresa,Mjesto) VALUES (@Ime,@Firma,@Tel,@Email,@Adresa,@Mjesto)", partner);
        }

        public void Update_Partner(Partner partner)
        {
            conn.Execute("UPDATE Partner SET Ime = @Ime, Firma = @Firma, Tel = @Tel, Email = @Email, Adresa = @Adresa, Mjesto = @Mjesto WHERE Id = @Id", partner);
        }

        public void Delete_Partner(int id)
        {
            conn.Execute("DELETE FROM Partner WHERE Id=@ID", new { ID = id });
        }

        bool PartnerTwoWay;
        public List<Partner> Get_AllSorted_Partner(string ColumnName)
        {
            if (PartnerTwoWay)
            {
                List<Partner> partneri = conn.Query<Partner>("SELECT * FROM Partner ORDER BY " + ColumnName).ToList();
                PartnerTwoWay = false;
                return partneri;
            }
            else
            {
                List<Partner> partneri = conn.Query<Partner>("SELECT * FROM Partner ORDER BY " + ColumnName + " DESC").ToList();
                PartnerTwoWay = true;
                return partneri;
            }
        }
        #endregion Partner

        #region Design
        public DesignGlobal GetAll_Designs()
        {

            List<DesignGlobal> globals = conn.Query<DesignGlobal>("SELECT * FROM DesignGlobal WHERE Id = 1").ToList();

            return globals[0];
        }

        public void Update_DesignGlobal(PanelColor color)
        {
            switch (color)
            {
                case PanelColor.darkBlue:
                    conn.Execute("UPDATE DesignGlobal SET darkBlue = 1,darkGreen = 0,darkOrange = 0,darkPurple = 0,darkRed = 0,darkYellow = 0,liteBlue = 0,liteGreen = 0,liteOrange = 0,litePurple = 0,liteRed = 0,liteYellow = 0,Defaultt = 0 WHERE Id = 1");
                    break;

                case PanelColor.darkGreen:
                    conn.Execute("UPDATE DesignGlobal SET darkBlue = 0,darkGreen = 1,darkOrange = 0,darkPurple = 0,darkRed = 0,darkYellow = 0,liteBlue = 0,liteGreen = 0,liteOrange = 0,litePurple = 0,liteRed = 0,liteYellow = 0,Defaultt = 0 WHERE Id = 1");
                    break;

                case PanelColor.darkOrange:
                    conn.Execute("UPDATE DesignGlobal SET darkBlue = 0,darkGreen = 0,darkOrange = 1,darkPurple = 0,darkRed = 0,darkYellow = 0,liteBlue = 0,liteGreen = 0,liteOrange = 0,litePurple = 0,liteRed = 0,liteYellow = 0,Defaultt = 0 WHERE Id = 1");
                    break;

                case PanelColor.darkPurple:
                    conn.Execute("UPDATE DesignGlobal SET darkBlue = 0,darkGreen = 0,darkOrange = 0,darkPurple = 1,darkRed = 0,darkYellow = 0,liteBlue = 0,liteGreen = 0,liteOrange = 0,litePurple = 0,liteRed = 0,liteYellow = 0,Defaultt = 0 WHERE Id = 1");
                    break;

                case PanelColor.darkRed:
                    conn.Execute("UPDATE DesignGlobal SET darkBlue = 0,darkGreen = 0,darkOrange = 0,darkPurple = 0,darkRed = 1,darkYellow = 0,liteBlue = 0,liteGreen = 0,liteOrange = 0,litePurple = 0,liteRed = 0,liteYellow = 0,Defaultt = 0 WHERE Id = 1");
                    break;

                case PanelColor.darkYellow:
                    conn.Execute("UPDATE DesignGlobal SET darkBlue = 0,darkGreen = 0,darkOrange = 0,darkPurple = 0,darkRed = 0,darkYellow = 1,liteBlue = 0,liteGreen = 0,liteOrange = 0,litePurple = 0,liteRed = 0,liteYellow = 0,Defaultt = 0 WHERE Id = 1");
                    break;

                case PanelColor.liteBlue:
                    conn.Execute("UPDATE DesignGlobal SET darkBlue = 0,darkGreen = 0,darkOrange = 0,darkPurple = 0,darkRed = 0,darkYellow = 0,liteBlue = 1,liteGreen = 0,liteOrange = 0,litePurple = 0,liteRed = 0,liteYellow = 0,Defaultt = 0 WHERE Id = 1");
                    break;

                case PanelColor.liteGreen:
                    conn.Execute("UPDATE DesignGlobal SET darkBlue = 0,darkGreen = 0,darkOrange = 0,darkPurple = 0,darkRed = 0,darkYellow = 0,liteBlue = 0,liteGreen = 1,liteOrange = 0,litePurple = 0,liteRed = 0,liteYellow = 0,Defaultt = 0 WHERE Id = 1");
                    break;

                case PanelColor.liteOrange:
                    conn.Execute("UPDATE DesignGlobal SET darkBlue = 0,darkGreen = 0,darkOrange = 0,darkPurple = 0,darkRed = 0,darkYellow = 0,liteBlue = 0,liteGreen = 0,liteOrange = 1,litePurple = 0,liteRed = 0,liteYellow = 0,Defaultt = 0 WHERE Id = 1");
                    break;

                case PanelColor.litePurple:
                    conn.Execute("UPDATE DesignGlobal SET darkBlue = 0,darkGreen = 0,darkOrange = 0,darkPurple = 0,darkRed = 0,darkYellow = 0,liteBlue = 0,liteGreen = 0,liteOrange = 0,litePurple = 1,liteRed = 0,liteYellow = 0,Defaultt = 0 WHERE Id = 1");
                    break;

                case PanelColor.liteRed:
                    conn.Execute("UPDATE DesignGlobal SET darkBlue = 0,darkGreen = 0,darkOrange = 0,darkPurple = 0,darkRed = 0,darkYellow = 0,liteBlue = 0,liteGreen = 0,liteOrange = 0,litePurple = 0,liteRed = 1,liteYellow = 0,Defaultt = 0 WHERE Id = 1");
                    break;

                case PanelColor.liteYellow:
                    conn.Execute("UPDATE DesignGlobal SET darkBlue = 0,darkGreen = 0,darkOrange = 0,darkPurple = 0,darkRed = 0,darkYellow = 0,liteBlue = 0,liteGreen = 0,liteOrange = 0,litePurple = 0,liteRed = 0,liteYellow = 1,Defaultt = 0 WHERE Id = 1");
                    break;
            }
        }
        #endregion Design

        #region Login
        public string GetPassword()
        {
            List<string> str = conn.Query<string>("SELECT Password FROM Login WHERE Id=1").ToList();
            return str[0];
        }

        public string GetUsername()
        {
            List<string> str = conn.Query<string>("SELECT Username FROM Login WHERE Id=1").ToList();
            return str[0];
        }

        public void UpdatePassword(string pass)
        {
            conn.Execute("UPDATE Login SET Password=@pas WHERE Id=1", new { pas = pass });
        }

        public void UpdateUsername(string username)
        {
            conn.Execute("UPDATE Login SET Username=@user WHERE Id=1", new { user = username });
        }
        #endregion Login

        #region Izvjestaj
        public List<Izvjestaj> GetAll_Izvjestaj(string name)
        {
            List<Izvjestaj> izvjestaji = conn.Query<Izvjestaj>("SELECT * FROM Izvjestaj" + name).ToList();
            return izvjestaji;
        }
        public List<Izvjestaj> GetAll_Izvjestaj()
        {
            List<Izvjestaj> izvjestaji = conn.Query<Izvjestaj>("SELECT * FROM Izvjestaj").ToList();
            return izvjestaji;
        }
        /// <summary>
        /// Function which will return one object 'Izvjestaj'
        /// </summary>
        /// <param name="Ime">Name for object which will be returned with earliest time</param>
        /// <returns></returns>
        public Izvjestaj GetByDate_Izvjestaj()
        {
            DateTime minDate = conn.ExecuteScalar<DateTime>("SELECT MAX(Date) FROM Izvjestaj");

            List<Izvjestaj> izvjestaji = conn.Query<Izvjestaj>("SELECT * FROM Izvjestaj WHERE Date=@Maxdate", new { Maxdate = minDate }).ToList();

            return izvjestaji[0];
        }

        public void Insert_Izvjestaj(Izvjestaj izvjestaj)
        {
            conn.Execute("INSERT INTO Izvjestaj (Ime,Cijena,Komada,Ukupno,Sveukupno,Date) VALUES (@Ime,@Cijena,@Komada,@Ukupno,@Sveukupno,@Date)", izvjestaj);
        }

        public void Delete_Izvjestaj(int id)
        {
            conn.Execute("DELETE FROM Izvjestaj WHERE Id=@ID", new { ID = id });
        }

        public void DeleteAll_Izvjestaj()
        {
            conn.Execute("DELETE FROM Izvjestaj");
        }


        public void Update_Izvjestaj(Izvjestaj izvjestaj)
        {
            conn.Execute("UPDATE Izvjestaj SET Ime=@Ime, Cijena=@Cijena, Komada=@Komada, Ukupno=@Ukupno, Sveukupno=@Sveukupno, Date=@Date WHERE Id=@Id", izvjestaj);
        }

        bool IzvjestajTwoWay;
        public List<Izvjestaj> Get_AllSorted_Izvjestaj(string ColumnName)
        {
            if (IzvjestajTwoWay)
            {
                List<Izvjestaj> izvjestaji = conn.Query<Izvjestaj>("SELECT * FROM Izvjestaj ORDER BY " + ColumnName).ToList();
                IzvjestajTwoWay = false;
                return izvjestaji;
            }
            else
            {
                List<Izvjestaj> izvjestaji = conn.Query<Izvjestaj>("SELECT * FROM Izvjestaj ORDER BY " + ColumnName + " DESC").ToList();
                IzvjestajTwoWay = true;
                return izvjestaji;
            }
        }
        #endregion Izvjestaj

        #region ProgramData
        public bool Get_FirstRun()
        {
            return conn.ExecuteScalar<bool>("SELECT FirstRun FROM ProgramData WHERE Id=1");
        }
        public void Set_FirstRun(bool bol)
        {
            conn.Execute("UPDATE ProgramData SET FirstRun=@value", new { value = bol });
        }

        public DateTime Get_ProgramDate()
        {
            return conn.ExecuteScalar<DateTime>("SELECT ProgramDate FROM ProgramData WHERE Id=1");
        }
        public void Set_ProgramDate(DateTime datetime)
        {
            conn.Execute("UPDATE ProgramData SET ProgramDate=@value", new { value = datetime });
        }

        public int Get_NumberOfFolders()
        {
            return conn.ExecuteScalar<int>("SELECT NumberOfFolders FROM ProgramData WHERE Id=1");
        }
        public void Set_NumberOfFolders(int NumberOfFolders)
        {
            conn.Execute("UPDATE ProgramData SET NumberOfFolders=@br WHERE Id=1", new { br = NumberOfFolders });
        }
        #endregion ProgramData

        public void CreateTable_Izvjestaj(string ime)
        {
            conn.Execute("CREATE TABLE [dbo].[Izvjestaj" + ime + "] ([Id] INT IDENTITY(1, 1) NOT NULL,[Ime] VARCHAR(50) NOT NULL,[Cijena] DECIMAL(18, 2) NOT NULL,[Komada] INT NOT NULL,[Ukupno] DECIMAL(18, 2) NOT NULL,[Sveukupno] DECIMAL(18, 2) NOT NULL,[Date] DATETIME NOT NULL,PRIMARY KEY CLUSTERED([Id] ASC));");
            conn.Execute("INSERT INTO Izvjestaj" + ime + " (Ime,Cijena,Komada,Ukupno,Sveukupno,Date) SELECT Ime, Cijena, Komada, Ukupno, Sveukupno, Date FROM Izvjestaj");
        }


        public void InsertGeneratedTableName_Izvjestaj(string Tablename, DateTime DATE)
        {
            conn.Execute("INSERT INTO Tables_Izvjestaji (Tablename,Date) VALUES (@name,@date)", new { name = Tablename, date = DATE });
        }

        public void DeleteGeneratedTableName_Izvjestaj(string Tablename)
        {
            conn.Execute("DELETE FROM Tables_Izvjestaji WHERE Tablename=@name", new { name = Tablename });
            conn.Execute("DROP TABLE " + Tablename);
        }

        public List<Tables_Izvjestaji> GetGeneratedTablesName_Izvjestaj()
        {
            List<Tables_Izvjestaji> tables = conn.Query<Tables_Izvjestaji>("SELECT * FROM Tables_Izvjestaji").ToList();
            return tables;
        }

    }
}
