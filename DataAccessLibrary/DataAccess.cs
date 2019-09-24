using Microsoft.Data.Sqlite;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace DataAccessLibrary
{
    public class BootsImport : INotifyPropertyChanged
    {
        public int BootsID { get; set; }
        public int Abteilung { get; set; }
        public int Startnummer { get; set; }
        public string Rennbezeichnung { get; set; }
        public string RennID
        {
            get => Imp_RennID;
            set
            {
                if (Imp_RennID != value)
                {
                    Imp_RennID = value;
                    Rennen _tmp = DataAccess.RennenLookuptable_Query(value);
                    this.Bootstyp = _tmp.Bootstyp;
                    this.Rennbezeichnung = _tmp.Rennbezeichnung;
                    this.ZuZahlen = _tmp.ZuZahlen;
                    this.BoolBezahlt = this.ZuZahlen <= this.Bezahlt;
                    DataAccess.UpdateBootsImport("RennID", value, this.BootsID);
                    DataAccess.UpdateBootsImport("Bootstyp", _tmp.Bootstyp, this.BootsID);
                    DataAccess.UpdateBootsImport("ZuZahlen", _tmp.ZuZahlen, this.BootsID);
                }
            }
        }
        public string Imp_RennID { get; set; }
        public string Bootsname
        {
            get => Imp_Bootsname;
            set
            {
                if (Imp_Bootsname != value)
                {
                    Imp_Bootsname = value;
                    DataAccess.UpdateBootsImport("Bootsname", value, this.BootsID);
                }
            }
        }
        public string Imp_Bootsname { get; set; }
        public string Verein
        {
            get => Imp_Verein;
            set
            {
                if (Imp_Verein != value)
                {
                    Imp_Verein = value;
                    DataAccess.UpdateBootsImport("Verein", value, this.BootsID);
                }
            }
        }
        public string Imp_Verein { get; set; }
        public string Steuerling
        {
            get => Imp_Steuerling;
            set
            {
                if (Imp_Steuerling != value)
                {
                    Imp_Steuerling = value;
                    DataAccess.UpdateBootsImport("Steuerling", value, this.BootsID);
                }
            }
        }
        public string Imp_Steuerling { get; set; }
        public string Athlet1
        {
            get => Imp_Athlet1;
            set
            {
                if (Imp_Athlet1 != value)
                {
                    Imp_Athlet1 = value;
                    DataAccess.UpdateBootsImport("Athlet1", value, this.BootsID);
                }
            }
        }
        public string Imp_Athlet1 { get; set; }
        public string Athlet2
        {
            get => Imp_Athlet2;
            set
            {
                if (Imp_Athlet2 != value)
                {
                    Imp_Athlet2 = value;
                    DataAccess.UpdateBootsImport("Athlet2", value, this.BootsID);
                }
            }
        }
        public string Imp_Athlet2 { get; set; }
        public string Athlet3
        {
            get => Imp_Athlet3;
            set
            {
                if (Imp_Athlet3 != value)
                {
                    Imp_Athlet3 = value;
                    DataAccess.UpdateBootsImport("Athlet3", value, this.BootsID);
                }
            }
        }
        public string Imp_Athlet3 { get; set; }
        public string Athlet4
        {
            get => Imp_Athlet4;
            set
            {
                if (Imp_Athlet4 != value)
                {
                    Imp_Athlet4 = value;
                    DataAccess.UpdateBootsImport("Athlet4", value, this.BootsID);
                }
            }
        }
        public string Imp_Athlet4 { get; set; }
        public string Athlet5
        {
            get => Imp_Athlet5;
            set
            {
                if (Imp_Athlet5 != value)
                {
                    Imp_Athlet5 = value;
                    DataAccess.UpdateBootsImport("Athlet5", value, this.BootsID);
                }
            }
        }
        public string Imp_Athlet5 { get; set; }
        public string Athlet6
        {
            get => Imp_Athlet6;
            set
            {
                if (Imp_Athlet6 != value)
                {
                    Imp_Athlet6 = value;
                    DataAccess.UpdateBootsImport("Athlet6", value, this.BootsID);
                }
            }
        }
        public string Imp_Athlet6 { get; set; }
        public string Athlet7
        {
            get => Imp_Athlet7;
            set
            {
                if (Imp_Athlet7 != value)
                {
                    Imp_Athlet7 = value;
                    DataAccess.UpdateBootsImport("Athlet7", value, this.BootsID);
                }
            }
        }
        public string Imp_Athlet7 { get; set; }
        public string Athlet8
        {
            get => Imp_Athlet8;
            set
            {
                if (Imp_Athlet8 != value)
                {
                    Imp_Athlet8 = value;
                    DataAccess.UpdateBootsImport("Athlet8", value, this.BootsID);
                }
            }
        }
        public string Imp_Athlet8 { get; set; }
        public string Meldername { get; set; }
        public string Melderadresse { get; set; }
        public string Melderort { get; set; }
        public string Melderverein { get; set; }
        public string Melderemail { get; set; }
        public string Meldertel { get; set; }
        public string Melderfax { get; set; }
        public decimal Bezahlt { get; set; }
        public decimal ZuZahlen { get; set; }
        public string Kommentare
        {
            get => Imp_Kommentare;
            set
            {
                if (Imp_Kommentare != value)
                {
                    Imp_Kommentare = value;
                    DataAccess.UpdateBootsImport("Kommentare", value, this.BootsID);
                }
            }
        }
        public string Imp_Kommentare { get; set; }
        public string Bootstyp { get; set; }
        public bool BoolBezahlt
        {
            get => Imp_BoolBezahlt;
            set
            {
                if (Imp_BoolBezahlt != value)
                {
                    Imp_BoolBezahlt = value;
                    if (value)
                    {
                        DataAccess.UpdateBootsImport("Bezahlt", this.ZuZahlen, this.BootsID);
                    }
                    else
                    {
                        DataAccess.UpdateBootsImport("Bezahlt", 0, this.BootsID);
                    }
                }
            }
        }
        public bool Imp_BoolBezahlt { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

#pragma warning disable IDE0051 // Nicht verwendete private Member entfernen
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
#pragma warning restore IDE0051 // Nicht verwendete private Member entfernen
    }

    public class Rennen
    {
        public string RennID { get; set; }
        public string Rennbezeichnung { get; set; }
        public decimal ZuZahlen { get; set; }
        public string Bootstyp { get; set; }
    }

    public class Boot : INotifyPropertyChanged
    {
        public int BootsID { get; set; }
        public int Abteilung { get; set; }

        public int Startnummer { get; set; }
        public string Rennbezeichnung { get; set; }
        public string Verein { get; set; }
        public string Steuerling { get; set; }
        public string Athlet1 { get; set; }
        public string Athlet2 { get; set; }
        public string Athlet3 { get; set; }
        public string Athlet4 { get; set; }
        public string Athlet5 { get; set; }
        public string Athlet6 { get; set; }
        public string Athlet7 { get; set; }
        public string Athlet8 { get; set; }
        public decimal Bezahlt { get; set; }
        public decimal ZuZahlen { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Codequalität", "IDE0051:Nicht verwendete private Member entfernen", Justification = "<Ausstehend>")]
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Verein : INotifyPropertyChanged
    {
        public string Vereinsname { get; set; }
        public int AnzahlBoote { get; set; }
        public decimal BisherGesammtBezahlt { get; set; }
        public decimal GesammtZuZahlen { get; set; }
        public decimal Total { get; set; }
        public ObservableCollection<Boot> VereinsBoote { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Codequalität", "IDE0051:Nicht verwendete private Member entfernen", Justification = "<Ausstehend>")]
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public static class DataAccess
    {
        private static readonly String sqliteConnectionString = "Filename=boote.db";

        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection(sqliteConnectionString))
            {
                db.Open();
                String CreateBoote = "CREATE TABLE IF NOT EXISTS Boote (BootsID INTEGER, Abteilung INTEGER, Startnummer INTEGER, "
                        + "Rennbezeichnung TEXT, Verein TEXT, Steuerling TEXT, Athlet1 TEXT, Athlet2 TEXT, "
                        + "Athlet3 TEXT, Athlet4 TEXT, Athlet5 TEXT, Athlet6 TEXT, Athlet7 TEXT, Athlet8 TEXT, "
                        + "Bezahlt REAL, ZuZahlen REAL);";
                using (SqliteCommand CreateBooteCommand = new SqliteCommand(CreateBoote, db))
                {
                    CreateBooteCommand.ExecuteReader();
                }

                String CreateProtoBoote = "CREATE TABLE IF NOT EXISTS ProtoBoote (BootsID INTEGER, Abteilung INTEGER, "
                        + "Startnummer INTEGER, Rennbezeichnung TEXT, RennID TEXT, Bootsname TEXT, Verein TEXT, "
                        + "Steuerling TEXT, Athlet1 TEXT, Athlet2 TEXT, Athlet3 TEXT, Athlet4 TEXT, Athlet5 TEXT, "
                        + "Athlet6 TEXT, Athlet7 TEXT, Athlet8 TEXT, Meldername TEXT, Melderadresse TEXT, "
                        + "Melderort TEXT, Melderverein TEXT, Melderemail TEXT, Meldertel TEXT, Melderfax TEXT, "
                        + "Bezahlt REAL, ZuZahlen REAL, Kommentare TEXT, Bootstyp TEXT);";

                using (SqliteCommand CreateProtoBooteCommand = new SqliteCommand(CreateProtoBoote, db))
                {
                    CreateProtoBooteCommand.ExecuteReader();
                }

                String CreateRennenLookuptable = "CREATE TABLE IF NOT EXISTS RennenLookuptable ('RennNr'  TEXT, "
                    + "'BootsTyp' TEXT, 'Bezeichnung' TEXT, 'Meldegeld' REAL, PRIMARY KEY('RennNr'));";

                using (SqliteCommand CreateRennenLookuptableCommand = new SqliteCommand(CreateRennenLookuptable, db))
                {
                    CreateRennenLookuptableCommand.ExecuteReader();
                }
                if (RennenLookuptable_isEmpty())
                {
                    FillRennenLookuptable();
                }
            }
        }

        public static bool RennenLookuptable_isEmpty()
        {
            const string RennenLookuptable_isEmptyDataQuery = "SELECT count(RennNr) FROM RennenLookuptable";
            using (SqliteConnection conn = new SqliteConnection(sqliteConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = RennenLookuptable_isEmptyDataQuery;
                    conn.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return reader.GetInt32(0) == 0;
                    }
                }
            }

        }

        public static void FillRennenLookuptable()
        {
            using (SqliteConnection db =
                new SqliteConnection(sqliteConnectionString))
            {
                db.Open();
                String insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES ('1', 'Rennb. (8+)', 'JF 8+ A  (Juniorinnen A)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('1a', 'Rennb. (8+)', 'JF 8+ B  (Juniorinnen B)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('2', 'Rennb. (8+)', 'MM/W 8+ A-K   (Masters A-K Mix)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('3', 'Rennb. (8+)', 'JM 8+ A  (Junioren A)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('3a', 'Rennb. (8+)', 'JM 8+ B  (Junioren B)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('4', 'Rennb. (8+)', 'SM/F 8+ A (SeniorInnen Mix)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('5', 'Rennb. (8+)', 'SF 8+ A/B  (Seniorinnen A/B)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('6', 'Rennb. (8+)', 'MW 8+ A-K  (Masters Frauen A-K)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('7', 'Rennb. (8+)', 'SM 8+ A/B  (Senioren A/B)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('8', 'Rennb. (8+)', 'MM 8+ A-K  (Masters Männer A-K)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('9', 'Rennb. (8+)', 'OFF 8+ (Offene Klasse; NUR Vereinsm.)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('10', 'Rennb. (8x+)', 'SM 8x+ A/B  (Senioren A/B)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('11', 'Rennb. (8x+)', 'SF 8x+ A/B  (Seniorinnen A/B)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('12', 'Rennb. (8x+)', 'MM 8x+ A-K  (Masters Männer A-K)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('13', 'Rennb. (8x+)', 'MW 8x+ A-K  (Masters Frauen A-K)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('14', 'Rennb. (8x+)', 'MM/W 8x+ A-K   (Masters A-K Mix)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('22', 'Gig (8+)', 'MM/W 8+ A-K   (Masters A-K Mix)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('24', 'Gig (8+)', 'SM/F 8+ A (SeniorInnen Mix)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('25', 'Gig (8+)', 'SF 8+ A/B  (Seniorinnen A/B)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('26', 'Gig (8+)', 'MW 8+ A-K  (Masters Frauen A-K)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('27', 'Gig (8+)', 'SM 8+ A/B  (Senioren A/B)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('28', 'Gig (8+)', 'MM 8+ A-K  (Masters Männer A-K)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('29', 'Gig (8+)', 'OFF 8+ (Offene Klasse; NUR Vereinsm.)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('30', 'Gig (8+/8x+)', 'Sportgruppe 8+/8x+ bis 42 Jahre', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('31', 'Gig (8+/8x+)', 'Sportgruppe 8+/8x+ ab 43 Jahre', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('33', 'Gig (8x+)', 'SM 8x+ A/B  (Senioren A/B)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('34', 'Gig (8x+)', 'SF 8x+ A/B  (Seniorinnen A/B)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('35', 'Gig (8x+)', 'MM 8x+ A-K  (Masters Männer A-K)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('36', 'Gig (8x+)', 'MW 8x+ A-K  (Masters Frauen A-K)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('37', 'Gig (8x+)', 'MM/W 8x+ A-K   (Masters A-K Mix)', '135');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('38', 'Gig (8x+)', 'JuM  8x+ 11-14 Jahre (alle Besetzungsarten)', '0');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
                insertintoRennenLookuptable = "INSERT INTO RennenLookuptable VALUES('32', 'Gig (8x+)', 'Schul 8x+ 11-14 Jahre (alle Besetzungsarten)', '0');";
                using (SqliteCommand insertintoRennenLookuptableCommand = new SqliteCommand(insertintoRennenLookuptable, db))
                {
                    insertintoRennenLookuptableCommand.ExecuteReader();
                }
            }
        }

        public static void Reset()
        {
            ResetBoote();
            ResetProtoBoote();
        }

        public static void ResetProtoBoote()
        {
            using (SqliteConnection db = new SqliteConnection(sqliteConnectionString))
            {
                db.Open();

                using (SqliteCommand insertCommand = new SqliteCommand())
                {
                    insertCommand.Connection = db;

                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "DROP TABLE ProtoBoote;";
                    insertCommand.ExecuteReader();

                    db.Close();
                }
            }
            InitializeDatabase();
        }

        public static void ResetBoote()
        {
            using (SqliteConnection db = new SqliteConnection(sqliteConnectionString))
            {
                db.Open();

                using (SqliteCommand insertCommand = new SqliteCommand())
                {
                    insertCommand.Connection = db;

                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "DROP TABLE Boote;";
                    insertCommand.ExecuteReader();

                    db.Close();
                }
            }
            InitializeDatabase();
        }


        public static void AddData(int BootsID, int Abteilung, int Startnummer, string Rennbezeichnung, string RennID, string Bootsname, string Verein, string Steuerling, string Athlet1, string Athlet2, string Athlet3, string Athlet4, string Athlet5, string Athlet6, string Athlet7, string Athlet8, string Meldername, string Melderadresse, string Melderort, string Melderverein, string Melderemail, string Meldertel, string Melderfax, decimal Bezahlt, string Kommentare)
        {
            Rennen temprennen = RennenLookuptable_Query(RennID);
            string _Bootstyp = temprennen.Bootstyp;
            string _Rennbezeichnung = temprennen.Rennbezeichnung + Rennbezeichnung;
            decimal _ZuZahlen = temprennen.ZuZahlen;
            Debug.WriteLine("BootID: " + BootsID);
            Debug.WriteLine("Bootstyp: " + _Bootstyp);
            Debug.WriteLine("Rennbezeichnung: " + _Rennbezeichnung);
            Debug.WriteLine("RennID: " + RennID);
            Debug.WriteLine("Bootsname: " + Bootsname);
            Debug.WriteLine("Verein: " + Verein);
            Debug.WriteLine("Steuerling: " + Steuerling);
            Debug.WriteLine("Athlet1: " + Athlet1);
            Debug.WriteLine("Athlet2: " + Athlet2);
            Debug.WriteLine("Athlet3: " + Athlet3);
            Debug.WriteLine("Athlet4: " + Athlet4);
            Debug.WriteLine("Athlet5: " + Athlet5);
            Debug.WriteLine("Athlet6: " + Athlet6);
            Debug.WriteLine("Athlet7: " + Athlet7);
            Debug.WriteLine("Athlet8: " + Athlet8);
            Debug.WriteLine("Meldername: " + Meldername);
            Debug.WriteLine("Melderadresse: " + Melderadresse);
            Debug.WriteLine("Melderort: " + Melderort);
            Debug.WriteLine("Melderverein: " + Melderverein);
            Debug.WriteLine("Melderemail: " + Melderemail);
            Debug.WriteLine("Meldertel: " + Meldertel);
            Debug.WriteLine("Melderfax: " + Melderfax);
            Debug.WriteLine("Kommentare: " + Kommentare);
            using (SqliteConnection db = new SqliteConnection(sqliteConnectionString))
            {
                db.Open();

                using (SqliteCommand insertCommand = new SqliteCommand())
                {
                    insertCommand.Connection = db;

                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "INSERT INTO ProtoBoote (BootsID, Abteilung, "
                        + "Startnummer, Rennbezeichnung, RennID, Bootsname, Verein, "
                        + "Steuerling, Athlet1, Athlet2, Athlet3, Athlet4, Athlet5, "
                        + "Athlet6, Athlet7, Athlet8, Meldername, Melderadresse, "
                        + "Melderort, Melderverein, Melderemail, Meldertel, Melderfax, "
                        + "Bezahlt, ZuZahlen, Kommentare, Bootstyp) "

                        + "VALUES('" + BootsID + "', '" + Abteilung
                        + "', '" + Startnummer + "', '" + _Rennbezeichnung
                        + "', '" + RennID + "', '" + Bootsname
                        + "', '" + Verein + "', '" + Steuerling
                        + "', '" + Athlet1 + "', '" + Athlet2
                        + "', '" + Athlet3 + "', '" + Athlet4
                        + "', '" + Athlet5 + "', '" + Athlet6
                        + "', '" + Athlet7 + "', '" + Athlet8
                        + "', '" + Meldername + "', '" + Melderadresse
                        + "', '" + Melderort + "', '" + Melderverein
                        + "', '" + Melderemail + "', '" + Meldertel
                        + "', '" + Melderfax + "', '" + Bezahlt
                        + "', '" + _ZuZahlen + "', '" + Kommentare
                        + "', '" + _Bootstyp + "'); ";
                    Debug.WriteLine(insertCommand.CommandText);
                    insertCommand.ExecuteReader();

                    db.Close();
                }
            }
        }

        public static Rennen RennenLookuptable_Query(string rennnr)
        {
            Rennen ctest = new Rennen();
            string RennenLookuptable_Query = "SELECT RennNr, BootsTyp, Bezeichnung, Meldegeld FROM RennenLookuptable where RennNr = '" + rennnr.ToLower() + "';";
            Debug.WriteLine(RennenLookuptable_Query);
            using (SqliteConnection conn = new SqliteConnection(sqliteConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = RennenLookuptable_Query;
                    conn.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        ctest.Bootstyp = reader.GetString(1);
                        ctest.Rennbezeichnung = reader.GetString(2);
                        ctest.ZuZahlen = reader.GetDecimal(3);
                    }
                }
            }
            return ctest;
        }


        public static ObservableCollection<BootsImport> GetImportdatenBearbeiten()
        {
            const string GetAllBoatDataQuery = "select BootsID, Abteilung, "
                        + "Startnummer, Rennbezeichnung, RennID, Bootsname, Verein, "
                        + "Steuerling, Athlet1, Athlet2, Athlet3, Athlet4, Athlet5, "
                        + "Athlet6, Athlet7, Athlet8, Meldername, Melderadresse, "
                        + "Melderort, Melderverein, Melderemail, Meldertel, Melderfax, "
                        + "Bezahlt, ZuZahlen, Kommentare, Bootstyp from ProtoBoote;";
            var boote = new ObservableCollection<BootsImport>();
            using (SqliteConnection conn = new SqliteConnection(sqliteConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = GetAllBoatDataQuery;
                    conn.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BootsImport boot = new BootsImport();
                            {
                                boot.BootsID = reader.GetInt32(0);
                                boot.Abteilung = reader.GetInt32(1);
                                boot.Startnummer = reader.GetInt32(2);
                                boot.Rennbezeichnung = reader.GetString(3);

                                boot.Imp_RennID = reader.GetString(4);
                                boot.RennID = boot.Imp_RennID;

                                boot.Imp_Bootsname = reader.GetString(5);
                                boot.Bootsname = boot.Imp_Bootsname;

                                boot.Imp_Verein = reader.GetString(6);
                                boot.Verein = boot.Imp_Verein;

                                boot.Imp_Steuerling = reader.GetString(7);
                                boot.Steuerling = boot.Imp_Steuerling;

                                boot.Imp_Athlet1 = reader.GetString(8);
                                boot.Athlet1 = boot.Imp_Athlet1;

                                boot.Imp_Athlet2 = reader.GetString(9);
                                boot.Athlet2 = boot.Imp_Athlet2;

                                boot.Imp_Athlet3 = reader.GetString(10);
                                boot.Athlet3 = boot.Imp_Athlet3;

                                boot.Imp_Athlet4 = reader.GetString(11);
                                boot.Athlet4 = boot.Imp_Athlet4;

                                boot.Imp_Athlet5 = reader.GetString(12);
                                boot.Athlet5 = boot.Imp_Athlet5;

                                boot.Imp_Athlet6 = reader.GetString(13);
                                boot.Athlet6 = boot.Imp_Athlet6;

                                boot.Imp_Athlet7 = reader.GetString(14);
                                boot.Athlet7 = boot.Imp_Athlet7;

                                boot.Imp_Athlet8 = reader.GetString(15);
                                boot.Athlet8 = boot.Imp_Athlet8;

                                boot.Meldername = reader.GetString(16);
                                boot.Melderadresse = reader.GetString(17);
                                boot.Melderort = reader.GetString(18);
                                boot.Melderverein = reader.GetString(19);
                                boot.Melderemail = reader.GetString(20);
                                boot.Meldertel = reader.GetString(21);
                                boot.Melderfax = reader.GetString(22);
                                boot.Bezahlt = reader.GetDecimal(23);
                                boot.ZuZahlen = reader.GetDecimal(24);

                                boot.Imp_Kommentare = reader.GetString(25);
                                boot.Kommentare = boot.Imp_Kommentare;

                                boot.Bootstyp = reader.GetString(26);

                                boot.Imp_BoolBezahlt = boot.Bezahlt >= boot.ZuZahlen;
                                boot.BoolBezahlt = boot.Imp_BoolBezahlt;
                                boote.Add(boot);
                            }
                        }
                    }
                }
            }
            return boote;
        }

        public static ObservableCollection<BootsImport> GetImportdatenBearbeiten(bool nurBootemitKommentarewerdenAngezeigtBool)
        {
            string GetAllBoatDataQuery = "select BootsID, Abteilung, "
                            + "Startnummer, Rennbezeichnung, RennID, Bootsname, Verein, "
                            + "Steuerling, Athlet1, Athlet2, Athlet3, Athlet4, Athlet5, "
                            + "Athlet6, Athlet7, Athlet8, Meldername, Melderadresse, "
                            + "Melderort, Melderverein, Melderemail, Meldertel, Melderfax, "
                            + "Bezahlt, ZuZahlen, Kommentare, Bootstyp from ProtoBoote";
            if (nurBootemitKommentarewerdenAngezeigtBool)
            {
                GetAllBoatDataQuery += " where NOT Kommentare = '';";
            }
            else
            {
                GetAllBoatDataQuery += ";";
            }

            var boote = new ObservableCollection<BootsImport>();
            using (SqliteConnection conn = new SqliteConnection(sqliteConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = GetAllBoatDataQuery;
                    conn.Open();
                    Debug.WriteLine(GetAllBoatDataQuery);
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BootsImport boot = new BootsImport();
                            {
                                boot.BootsID = reader.GetInt32(0);
                                boot.Abteilung = reader.GetInt32(1);
                                boot.Startnummer = reader.GetInt32(2);
                                boot.Rennbezeichnung = reader.GetString(3);

                                boot.Imp_RennID = reader.GetString(4);
                                boot.RennID = boot.Imp_RennID;

                                boot.Imp_Bootsname = reader.GetString(5);
                                boot.Bootsname = boot.Imp_Bootsname;

                                boot.Imp_Verein = reader.GetString(6);
                                boot.Verein = boot.Imp_Verein;

                                boot.Imp_Steuerling = reader.GetString(7);
                                boot.Steuerling = boot.Imp_Steuerling;

                                boot.Imp_Athlet1 = reader.GetString(8);
                                boot.Athlet1 = boot.Imp_Athlet1;

                                boot.Imp_Athlet2 = reader.GetString(9);
                                boot.Athlet2 = boot.Imp_Athlet2;

                                boot.Imp_Athlet3 = reader.GetString(10);
                                boot.Athlet3 = boot.Imp_Athlet3;

                                boot.Imp_Athlet4 = reader.GetString(11);
                                boot.Athlet4 = boot.Imp_Athlet4;

                                boot.Imp_Athlet5 = reader.GetString(12);
                                boot.Athlet5 = boot.Imp_Athlet5;

                                boot.Imp_Athlet6 = reader.GetString(13);
                                boot.Athlet6 = boot.Imp_Athlet6;

                                boot.Imp_Athlet7 = reader.GetString(14);
                                boot.Athlet7 = boot.Imp_Athlet7;

                                boot.Imp_Athlet8 = reader.GetString(15);
                                boot.Athlet8 = boot.Imp_Athlet8;

                                boot.Meldername = reader.GetString(16);
                                boot.Melderadresse = reader.GetString(17);
                                boot.Melderort = reader.GetString(18);
                                boot.Melderverein = reader.GetString(19);
                                boot.Melderemail = reader.GetString(20);
                                boot.Meldertel = reader.GetString(21);
                                boot.Melderfax = reader.GetString(22);
                                boot.Bezahlt = reader.GetDecimal(23);
                                boot.ZuZahlen = reader.GetDecimal(24);

                                boot.Imp_Kommentare = reader.GetString(25);
                                boot.Kommentare = boot.Imp_Kommentare;

                                boot.Bootstyp = reader.GetString(26);

                                boot.Imp_BoolBezahlt = boot.Bezahlt >= boot.ZuZahlen;
                                boot.BoolBezahlt = boot.Imp_BoolBezahlt;
                                boote.Add(boot);
                            }
                        }
                    }
                }
            }
            return boote;
        }


        public static ObservableCollection<BootsImport> GetImportdatenBearbeiten(int Abteilungsnummer)
        {
            string GetAllBoatDataQuery = "select BootsID, Abteilung, "
                        + "Startnummer, Rennbezeichnung, RennID, Bootsname, Verein, "
                        + "Steuerling, Athlet1, Athlet2, Athlet3, Athlet4, Athlet5, "
                        + "Athlet6, Athlet7, Athlet8, Meldername, Melderadresse, "
                        + "Melderort, Melderverein, Melderemail, Meldertel, Melderfax, "
                        + "Bezahlt, ZuZahlen, Kommentare, Bootstyp from ProtoBoote where Abteilung = '" + Abteilungsnummer + "';";
            var boote = new ObservableCollection<BootsImport>();
            using (SqliteConnection conn = new SqliteConnection(sqliteConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = GetAllBoatDataQuery;
                    conn.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BootsImport boot = new BootsImport();
                            {
                                boot.BootsID = reader.GetInt32(0);
                                boot.Abteilung = reader.GetInt32(1);
                                boot.Startnummer = reader.GetInt32(2);
                                boot.Rennbezeichnung = reader.GetString(3);

                                boot.Imp_RennID = reader.GetString(4);
                                boot.RennID = boot.Imp_RennID;

                                boot.Imp_Bootsname = reader.GetString(5);
                                boot.Bootsname = boot.Imp_Bootsname;

                                boot.Imp_Verein = reader.GetString(6);
                                boot.Verein = boot.Imp_Verein;

                                boot.Imp_Steuerling = reader.GetString(7);
                                boot.Steuerling = boot.Imp_Steuerling;

                                boot.Imp_Athlet1 = reader.GetString(8);
                                boot.Athlet1 = boot.Imp_Athlet1;

                                boot.Imp_Athlet2 = reader.GetString(9);
                                boot.Athlet2 = boot.Imp_Athlet2;

                                boot.Imp_Athlet3 = reader.GetString(10);
                                boot.Athlet3 = boot.Imp_Athlet3;

                                boot.Imp_Athlet4 = reader.GetString(11);
                                boot.Athlet4 = boot.Imp_Athlet4;

                                boot.Imp_Athlet5 = reader.GetString(12);
                                boot.Athlet5 = boot.Imp_Athlet5;

                                boot.Imp_Athlet6 = reader.GetString(13);
                                boot.Athlet6 = boot.Imp_Athlet6;

                                boot.Imp_Athlet7 = reader.GetString(14);
                                boot.Athlet7 = boot.Imp_Athlet7;

                                boot.Imp_Athlet8 = reader.GetString(15);
                                boot.Athlet8 = boot.Imp_Athlet8;

                                boot.Meldername = reader.GetString(16);
                                boot.Melderadresse = reader.GetString(17);
                                boot.Melderort = reader.GetString(18);
                                boot.Melderverein = reader.GetString(19);
                                boot.Melderemail = reader.GetString(20);
                                boot.Meldertel = reader.GetString(21);
                                boot.Melderfax = reader.GetString(22);
                                boot.Bezahlt = reader.GetDecimal(23);
                                boot.ZuZahlen = reader.GetDecimal(24);

                                boot.Imp_Kommentare = reader.GetString(25);
                                boot.Kommentare = boot.Imp_Kommentare;

                                boot.Bootstyp = reader.GetString(26);

                                boot.Imp_BoolBezahlt = boot.Bezahlt >= boot.ZuZahlen;
                                boot.BoolBezahlt = boot.Imp_BoolBezahlt;
                                boote.Add(boot);
                            }
                        }
                    }
                }
                return boote;
            }
        }


        public static ObservableCollection<Boot> GetBooteBootssuche()
        {
            const string GetAllBoatDataQuery = "select abteilung, startnummer, Rennbezeichnung, "
                        + "verein, steuerling, athlet1, athlet2, athlet3, athlet4, athlet5, "
                        + "athlet6, athlet7, athlet8, bezahlt, zuZahlen from ProtoBoote;";
            var boote = new ObservableCollection<Boot>();
            using (SqliteConnection conn = new SqliteConnection(sqliteConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = GetAllBoatDataQuery;
                    conn.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var boot = new Boot
                            {
                                Abteilung = reader.GetInt32(0),
                                Startnummer = reader.GetInt32(1),
                                Rennbezeichnung = reader.GetString(2),
                                Verein = reader.GetString(3),
                                Steuerling = reader.GetString(4),
                                Athlet1 = reader.GetString(5),
                                Athlet2 = reader.GetString(6),
                                Athlet3 = reader.GetString(7),
                                Athlet4 = reader.GetString(8),
                                Athlet5 = reader.GetString(9),
                                Athlet6 = reader.GetString(10),
                                Athlet7 = reader.GetString(11),
                                Athlet8 = reader.GetString(12),
                                Bezahlt = reader.GetDecimal(13),
                                ZuZahlen = reader.GetDecimal(14)
                            };
                            boote.Add(boot);
                        }
                    }
                }
            }
            return boote;
        }

        public static ObservableCollection<Boot> GetBooteByVereinVereinssuche(string verein)
        {
            string GetAllBoatDataQuery = "select abteilung, startnummer, Rennbezeichnung, verein, steuerling, "
                        + "athlet1, athlet2, athlet3, athlet4, athlet5, athlet6, athlet7, athlet8, "
                        + "bezahlt, zuZahlen from Boote where verein = '" + verein + "';";
            var boote = new ObservableCollection<Boot>();
            using (SqliteConnection conn = new SqliteConnection(sqliteConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = GetAllBoatDataQuery;
                    conn.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var boot = new Boot
                            {
                                Abteilung = reader.GetInt32(0),
                                Startnummer = reader.GetInt32(1),
                                Rennbezeichnung = reader.GetString(2),
                                Verein = reader.GetString(3),
                                Steuerling = reader.GetString(4),
                                Athlet1 = reader.GetString(5),
                                Athlet2 = reader.GetString(6),
                                Athlet3 = reader.GetString(7),
                                Athlet4 = reader.GetString(8),
                                Athlet5 = reader.GetString(9),
                                Athlet6 = reader.GetString(10),
                                Athlet7 = reader.GetString(11),
                                Athlet8 = reader.GetString(12),
                                Bezahlt = reader.GetDecimal(13),
                                ZuZahlen = reader.GetDecimal(14)
                            };
                            boote.Add(boot);
                        }
                    }
                }
            }
            return boote;
        }

        public static ObservableCollection<Verein> GetVereineVereinssuche()
        {
            const string GetAllVereineDataQuery = "SELECT verein, count(verein) AS anzahlBoote, "
                        + "sum(bezahlt) as bisherGesammtBezahlt, sum(zuZahlen) as gesammtZuZahlen, "
                        + "sum(bezahlt) - sum(zuZahlen) as total FROM ProtoBoote GROUP BY verein order by count(verein) DESC, verein ASC";
            var vereine = new ObservableCollection<Verein>();
            using (SqliteConnection conn = new SqliteConnection(sqliteConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = GetAllVereineDataQuery;
                    conn.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var vereintmp = new Verein
                            {
                                Vereinsname = reader.GetString(0),
                                AnzahlBoote = reader.GetInt32(1),
                                BisherGesammtBezahlt = reader.GetDecimal(2),
                                GesammtZuZahlen = reader.GetDecimal(3),
                                Total = reader.GetDecimal(4)
                            };
                            vereintmp.VereinsBoote = GetBooteByVereinVereinssuche(vereintmp.Vereinsname);
                            vereine.Add(vereintmp);
                        }
                    }
                }
            }
            return vereine;
        }

        internal static void UpdateBootsImport(string zeilenName, object updateWert, int BootsID)
        {

            string UpdateOneBoatData =
                "UPDATE ProtoBoote "
                + "SET '" + zeilenName + "' = '" + updateWert.ToString()
                + "' WHERE BootsID = '" + BootsID.ToString() + "';";
            Debug.WriteLine(UpdateOneBoatData);
            using (SqliteConnection db =
                new SqliteConnection(sqliteConnectionString))
            {
                db.Open();
                using (SqliteCommand CreateBooteCommand = new SqliteCommand(UpdateOneBoatData, db))
                {
                    CreateBooteCommand.ExecuteReader();
                }
            }
        }
    }
}