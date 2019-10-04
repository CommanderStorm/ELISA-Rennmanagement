using Microsoft.Data.Sqlite;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DataAccessLibrary
{
    public static class DataAccess
    {
        private static readonly String sqliteConnectionString = "Filename=boote.db";

        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection(sqliteConnectionString))
            {
                db.Open();
                String CreateBoote = "CREATE TABLE IF NOT EXISTS Boote ('BootsID' INTEGER NOT NULL UNIQUE, 'Abteilung' INTEGER, "
                    + "'Startnummer' INTEGER, 'RennID' TEXT, 'Bootsname' TEXT, 'GesammtVerein' TEXT, "
                    + "'SteuerlingID' INTEGER, 'Athlet1ID'   INTEGER, 'Athlet2ID'   INTEGER, 'Athlet3ID'   INTEGER, 'Athlet4ID'   INTEGER, "
                    + "'Athlet5ID'   INTEGER, 'Athlet6ID'   INTEGER, 'Athlet7ID'   INTEGER, 'Athlet8ID'   INTEGER, 'Meldername' TEXT, "
                    + "'Melderadresse' TEXT, 'Melderort' TEXT, 'Melderverein'  TEXT, 'Melderemail'   TEXT, 'Meldertel' TEXT, "
                    + "'Melderfax' TEXT, 'Bezahlt'   REAL, 'ZuZahlen'  REAL, 'Kommentare' TEXT, "
                    + "PRIMARY KEY('BootsID'))";

                using (SqliteCommand CreateBooteCommand = new SqliteCommand(CreateBoote, db))
                {
                    CreateBooteCommand.ExecuteReader();
                }

                String CreatePersonen = "CREATE TABLE IF NOT EXISTS Personen ('Name' TEXT, "
                    + "'Verein' TEXT); ";

                using (SqliteCommand CreateRennenLookuptableCommand = new SqliteCommand(CreatePersonen, db))
                {
                    CreateRennenLookuptableCommand.ExecuteReader();
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
            ResetPersonen();
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

        public static void ResetPersonen()
        {
            using (SqliteConnection db = new SqliteConnection(sqliteConnectionString))
            {
                db.Open();

                using (SqliteCommand insertCommand = new SqliteCommand())
                {
                    insertCommand.Connection = db;

                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "DROP TABLE Personen;";
                    insertCommand.ExecuteReader();

                    db.Close();
                }
            }
            InitializeDatabase();
        }


        public static void AddData(int BootsID, int Abteilung, int Startnummer,
            string RennID, string Bootsname, string Verein, string Steuerling, string SteuerlingVerein,
            string Athlet1, string Athlet1Verein, string Athlet2, string Athlet2Verein, string Athlet3, string Athlet3Verein,
            string Athlet4, string Athlet4Verein, string Athlet5, string Athlet5Verein, string Athlet6, string Athlet6Verein,
            string Athlet7, string Athlet7Verein, string Athlet8, string Athlet8Verein,
            string Meldername, string Melderadresse, string Melderort, string Melderverein, string Melderemail, string Meldertel, string Melderfax,
            decimal Bezahlt, string Kommentare)
        {
            Rennen temprennen = RennenLookuptable_Query(RennID);
            decimal _ZuZahlen = temprennen.ZuZahlen;
            /*
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
            */
            int SteuerlingID = GetOrSetPersonenID(Steuerling, SteuerlingVerein);
            int Athlet1ID = GetOrSetPersonenID(Athlet1, Athlet1Verein);
            int Athlet2ID = GetOrSetPersonenID(Athlet2, Athlet2Verein);
            int Athlet3ID = GetOrSetPersonenID(Athlet3, Athlet3Verein);
            int Athlet4ID = GetOrSetPersonenID(Athlet4, Athlet4Verein);
            int Athlet5ID = GetOrSetPersonenID(Athlet5, Athlet5Verein);
            int Athlet6ID = GetOrSetPersonenID(Athlet6, Athlet6Verein);
            int Athlet7ID = GetOrSetPersonenID(Athlet7, Athlet7Verein);
            int Athlet8ID = GetOrSetPersonenID(Athlet8, Athlet8Verein);
            using (SqliteConnection db = new SqliteConnection(sqliteConnectionString))
            {
                db.Open();

                using (SqliteCommand insertCommand = new SqliteCommand())
                {
                    insertCommand.Connection = db;

                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "INSERT INTO Boote (BootsID, Abteilung, "
                        + "Startnummer, RennID, Bootsname, GesammtVerein, "
                        + "SteuerlingID, Athlet1ID, Athlet2ID, Athlet3ID, Athlet4ID, Athlet5ID, "
                        + "Athlet6ID, Athlet7ID, Athlet8ID, Meldername, Melderadresse, "
                        + "Melderort, Melderverein, Melderemail, Meldertel, Melderfax, "
                        + "Bezahlt, ZuZahlen, Kommentare) "

                        + "VALUES('" + BootsID + "', '" + Abteilung
                        + "', '" + Startnummer
                        + "', '" + RennID + "', '" + Bootsname
                        + "', '" + Verein + "', '" + SteuerlingID
                        + "', '" + Athlet1ID + "', '" + Athlet2ID
                        + "', '" + Athlet3ID + "', '" + Athlet4ID
                        + "', '" + Athlet5ID + "', '" + Athlet6ID
                        + "', '" + Athlet7ID + "', '" + Athlet8ID
                        + "', '" + Meldername + "', '" + Melderadresse
                        + "', '" + Melderort + "', '" + Melderverein
                        + "', '" + Melderemail + "', '" + Meldertel
                        + "', '" + Melderfax + "', '" + Bezahlt
                        + "', '" + _ZuZahlen + "', '" + Kommentare
                        + "'); ";
                    Debug.WriteLine(insertCommand.CommandText);
                    insertCommand.ExecuteReader();

                    db.Close();
                }
            }
        }

        private static int GetOrSetPersonenID(string personenName, string personenVerein)
        {
            if (PersonIsNOTInDatabase(personenName, personenVerein))
            {
                using (SqliteConnection db = new SqliteConnection(sqliteConnectionString))
                {
                    db.Open();

                    using (SqliteCommand insertCommand = new SqliteCommand())
                    {
                        insertCommand.Connection = db;

                        // Use parameterized query to prevent SQL injection attacks
                        insertCommand.CommandText = "INSERT INTO Personen (Name, "
                            + "Verein) "

                            + "VALUES('" + personenName + "', '" + personenVerein + "'); ";
                        Debug.WriteLine(insertCommand.CommandText);
                        insertCommand.ExecuteReader();

                        db.Close();
                    }
                }
            }
            return GetPersonenID(personenName, personenVerein);
        }

        private static int GetPersonenID(string personenName, string personenVerein)
        {
            string personIsAlreadyInDatabaseGetIDQuery = "SELECT ROWID FROM Personen WHERE Name = '" + personenName + "' AND Verein = '" + personenVerein + "';";
            using (SqliteConnection conn = new SqliteConnection(sqliteConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = personIsAlreadyInDatabaseGetIDQuery;
                    conn.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return reader.GetInt32(0);
                    }
                }
            }
        }

        private static bool PersonIsNOTInDatabase(string personenName, string personenVerein)
        {
            string personIsAlreadyInDatabaseQuery = "SELECT count(*) FROM Personen WHERE Name = '" + personenName + "' AND Verein = '" + personenVerein + "';";
            using (SqliteConnection conn = new SqliteConnection(sqliteConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = personIsAlreadyInDatabaseQuery;
                    conn.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return reader.GetInt32(0) == 0;
                    }
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Codequalität", "IDE0051:Nicht verwendete private Member entfernen", Justification = "<Ausstehend>")]
        private static bool PersonDoesNOTmatchDatabase(string personenName, int rowID)
        {
            string personIsAlreadyInDatabaseQuery = "SELECT count(*) FROM Personen WHERE Name = '" + personenName + "' AND ROWID = '" + rowID + "';";
            using (SqliteConnection conn = new SqliteConnection(sqliteConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = personIsAlreadyInDatabaseQuery;
                    conn.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return reader.GetInt32(0) == 0;
                    }
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


        public static ObservableCollection<BootEditable> GetDatenBearbeiten()
        {
            const string GetAllBoatDataQuery = "select BootsID, Abteilung, "
                        + "Startnummer, RennID, Bootsname, GesammtVerein, "
                        + "SteuerlingID, Athlet1ID, Athlet2ID, Athlet3ID, Athlet4ID, Athlet5ID, "
                        + "Athlet6ID, Athlet7ID, Athlet8ID, Meldername, Melderadresse, "
                        + "Melderort, Melderverein, Melderemail, Meldertel, Melderfax, "
                        + "Bezahlt, ZuZahlen, Kommentare from Boote;";
            var boote = new ObservableCollection<BootEditable>();
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
                            BootEditable boot = new BootEditable();
                            {
                                boot.BootsID = reader.GetInt32(0);
                                boot.Abteilung = reader.GetInt32(1);
                                boot.Startnummer = reader.GetInt32(2);

                                boot.Imp_RennID = reader.GetString(3);
                                boot.RennID = boot.Imp_RennID;

                                boot.Imp_Bootsname = reader.GetString(4);
                                boot.Bootsname = boot.Imp_Bootsname;

                                boot.Imp_Verein = reader.GetString(5);
                                boot.Verein = boot.Imp_Verein;

                                boot.SteuerlingID = reader.GetInt32(6);
                                boot.Steuerling = GetNameByID(boot.SteuerlingID);

                                boot.Athlet1ID = reader.GetInt32(7);
                                boot.Athlet1 = GetNameByID(boot.Athlet1ID);

                                boot.Athlet2ID = reader.GetInt32(8);
                                boot.Athlet2 = GetNameByID(boot.Athlet2ID);

                                boot.Athlet3ID = reader.GetInt32(9);
                                boot.Athlet3 = GetNameByID(boot.Athlet3ID);

                                boot.Athlet4ID = reader.GetInt32(10);
                                boot.Athlet4 = GetNameByID(boot.Athlet4ID);

                                boot.Athlet5ID = reader.GetInt32(11);
                                boot.Athlet5 = GetNameByID(boot.Athlet5ID);

                                boot.Athlet6ID = reader.GetInt32(12);
                                boot.Athlet6 = GetNameByID(boot.Athlet6ID);

                                boot.Athlet7ID = reader.GetInt32(13);
                                boot.Athlet7 = GetNameByID(boot.Athlet7ID);

                                boot.Athlet8ID = reader.GetInt32(14);
                                boot.Athlet8 = GetNameByID(boot.Athlet8ID);

                                boot.Meldername = reader.GetString(15);
                                boot.Melderadresse = reader.GetString(16);
                                boot.Melderort = reader.GetString(17);
                                boot.Melderverein = reader.GetString(18);
                                boot.Melderemail = reader.GetString(19);
                                boot.Meldertel = reader.GetString(20);
                                boot.Melderfax = reader.GetString(21);
                                boot.Bezahlt = reader.GetDecimal(22);
                                boot.ZuZahlen = reader.GetDecimal(23);

                                boot.Imp_Kommentare = reader.GetString(24);
                                boot.Kommentare = boot.Imp_Kommentare;

                                boot.Imp_BoolBezahlt = boot.Bezahlt >= boot.ZuZahlen;
                                boot.BoolBezahlt = boot.Imp_BoolBezahlt;
                                Rennen _rennen = RennenLookuptable_Query(boot.RennID);
                                boot.Bootstyp = _rennen.Bootstyp;
                                boot.Rennbezeichnung = _rennen.Rennbezeichnung;
                                boote.Add(boot);
                            }
                        }
                    }
                }
            }
            return boote;
        }

        private static string GetNameByID(int rowID)
        {
            string personIsAlreadyInDatabaseQuery = "SELECT Name FROM Personen WHERE ROWID = '" + rowID + "';";
            using (SqliteConnection conn = new SqliteConnection(sqliteConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = personIsAlreadyInDatabaseQuery;
                    conn.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return reader.GetString(0);
                    }
                }
            }
        }

        public static ObservableCollection<BootEditable> GetDatenBearbeiten(bool nurBootemitKommentarewerdenAngezeigtBool)
        {
            string GetAllBoatDataQuery = "select BootsID, Abteilung, "
                            + "Startnummer, RennID, Bootsname, GesammtVerein, "
                            + "SteuerlingID, Athlet1ID, Athlet2ID, Athlet3ID, Athlet4ID, Athlet5ID, "
                            + "Athlet6ID, Athlet7ID, Athlet8ID, Meldername, Melderadresse, "
                            + "Melderort, Melderverein, Melderemail, Meldertel, Melderfax, "
                            + "Bezahlt, ZuZahlen, Kommentare from Boote";
            if (nurBootemitKommentarewerdenAngezeigtBool)
            {
                GetAllBoatDataQuery += " where NOT Kommentare = '';";
            }
            else
            {
                GetAllBoatDataQuery += ";";
            }

            var boote = new ObservableCollection<BootEditable>();
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
                            BootEditable boot = new BootEditable();
                            {
                                boot.BootsID = reader.GetInt32(0);
                                boot.Abteilung = reader.GetInt32(1);
                                boot.Startnummer = reader.GetInt32(2);

                                boot.Imp_RennID = reader.GetString(3);
                                boot.RennID = boot.Imp_RennID;

                                boot.Imp_Bootsname = reader.GetString(4);
                                boot.Bootsname = boot.Imp_Bootsname;

                                boot.Imp_Verein = reader.GetString(5);
                                boot.Verein = boot.Imp_Verein;

                                boot.SteuerlingID = reader.GetInt32(6);
                                boot.Steuerling = GetNameByID(boot.SteuerlingID);

                                boot.Athlet1ID = reader.GetInt32(7);
                                boot.Athlet1 = GetNameByID(boot.Athlet1ID);

                                boot.Athlet2ID = reader.GetInt32(8);
                                boot.Athlet2 = GetNameByID(boot.Athlet2ID);

                                boot.Athlet3ID = reader.GetInt32(9);
                                boot.Athlet3 = GetNameByID(boot.Athlet3ID);

                                boot.Athlet4ID = reader.GetInt32(10);
                                boot.Athlet4 = GetNameByID(boot.Athlet4ID);

                                boot.Athlet5ID = reader.GetInt32(11);
                                boot.Athlet5 = GetNameByID(boot.Athlet5ID);

                                boot.Athlet6ID = reader.GetInt32(12);
                                boot.Athlet6 = GetNameByID(boot.Athlet6ID);

                                boot.Athlet7ID = reader.GetInt32(13);
                                boot.Athlet7 = GetNameByID(boot.Athlet7ID);

                                boot.Athlet8ID = reader.GetInt32(14);
                                boot.Athlet8 = GetNameByID(boot.Athlet8ID);

                                boot.Meldername = reader.GetString(15);
                                boot.Melderadresse = reader.GetString(16);
                                boot.Melderort = reader.GetString(17);
                                boot.Melderverein = reader.GetString(18);
                                boot.Melderemail = reader.GetString(19);
                                boot.Meldertel = reader.GetString(20);
                                boot.Melderfax = reader.GetString(21);
                                boot.Bezahlt = reader.GetDecimal(22);
                                boot.ZuZahlen = reader.GetDecimal(23);

                                boot.Imp_Kommentare = reader.GetString(24);
                                boot.Kommentare = boot.Imp_Kommentare;

                                boot.Imp_BoolBezahlt = boot.Bezahlt >= boot.ZuZahlen;
                                boot.BoolBezahlt = boot.Imp_BoolBezahlt;
                                Rennen _rennen = RennenLookuptable_Query(boot.RennID);
                                boot.Bootstyp = _rennen.Bootstyp;
                                boot.Rennbezeichnung = _rennen.Rennbezeichnung;
                                boote.Add(boot);
                            }
                        }
                    }
                }
            }
            return boote;
        }


        public static ObservableCollection<BootEditable> GetDatenBearbeiten(int Abteilungsnummer)
        {
            string GetAllBoatDataQuery = "select BootsID, Abteilung, "
                        + "Startnummer, RennID, Bootsname, GesammtVerein, "
                        + "SteuerlingID, Athlet1ID, Athlet2ID, Athlet3ID, Athlet4ID, Athlet5ID, "
                        + "Athlet6ID, Athlet7ID, Athlet8ID, Meldername, Melderadresse, "
                        + "Melderort, Melderverein, Melderemail, Meldertel, Melderfax, "
                        + "Bezahlt, ZuZahlen, Kommentare from Boote where Abteilung = '" + Abteilungsnummer + "';";
            var boote = new ObservableCollection<BootEditable>();
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
                            BootEditable boot = new BootEditable();
                            {
                                boot.BootsID = reader.GetInt32(0);
                                boot.Abteilung = reader.GetInt32(1);
                                boot.Startnummer = reader.GetInt32(2);

                                boot.Imp_RennID = reader.GetString(3);
                                boot.RennID = boot.Imp_RennID;

                                boot.Imp_Bootsname = reader.GetString(4);
                                boot.Bootsname = boot.Imp_Bootsname;

                                boot.Imp_Verein = reader.GetString(5);
                                boot.Verein = boot.Imp_Verein;

                                boot.SteuerlingID = reader.GetInt32(6);
                                boot.Steuerling = GetNameByID(boot.SteuerlingID);

                                boot.Athlet1ID = reader.GetInt32(7);
                                boot.Athlet1 = GetNameByID(boot.Athlet1ID);

                                boot.Athlet2ID = reader.GetInt32(8);
                                boot.Athlet2 = GetNameByID(boot.Athlet2ID);

                                boot.Athlet3ID = reader.GetInt32(9);
                                boot.Athlet3 = GetNameByID(boot.Athlet3ID);

                                boot.Athlet4ID = reader.GetInt32(10);
                                boot.Athlet4 = GetNameByID(boot.Athlet4ID);

                                boot.Athlet5ID = reader.GetInt32(11);
                                boot.Athlet5 = GetNameByID(boot.Athlet5ID);

                                boot.Athlet6ID = reader.GetInt32(12);
                                boot.Athlet6 = GetNameByID(boot.Athlet6ID);

                                boot.Athlet7ID = reader.GetInt32(13);
                                boot.Athlet7 = GetNameByID(boot.Athlet7ID);

                                boot.Athlet8ID = reader.GetInt32(14);
                                boot.Athlet8 = GetNameByID(boot.Athlet8ID);

                                boot.Meldername = reader.GetString(15);
                                boot.Melderadresse = reader.GetString(16);
                                boot.Melderort = reader.GetString(17);
                                boot.Melderverein = reader.GetString(18);
                                boot.Melderemail = reader.GetString(19);
                                boot.Meldertel = reader.GetString(20);
                                boot.Melderfax = reader.GetString(21);
                                boot.Bezahlt = reader.GetDecimal(22);
                                boot.ZuZahlen = reader.GetDecimal(23);

                                boot.Imp_Kommentare = reader.GetString(24);
                                boot.Kommentare = boot.Imp_Kommentare;

                                boot.Imp_BoolBezahlt = boot.Bezahlt >= boot.ZuZahlen;
                                boot.BoolBezahlt = boot.Imp_BoolBezahlt;
                                Rennen _rennen = RennenLookuptable_Query(boot.RennID);
                                boot.Bootstyp = _rennen.Bootstyp;
                                boot.Rennbezeichnung = _rennen.Rennbezeichnung;
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
            const string GetAllBoatDataQuery = "select BootsID, Abteilung, Startnummer, "
                        + "RennID, GesammtVerein, SteuerlingID, Athlet1ID, Athlet2ID, "
                        + "Athlet3ID, Athlet4ID, Athlet5ID, Athlet6ID, Athlet7ID, Athlet8ID, Meldername, "
                        + "Melderadresse, Melderort, Melderverein, Melderemail, Meldertel, Melderfax, "
                        + "Bezahlt, ZuZahlen, Bootsname from Boote;";
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
                            Boot boot = new Boot
                            {
                                BootsID = reader.GetInt32(0),
                                Abteilung = reader.GetInt32(1),
                                Startnummer = reader.GetInt32(2),
                                RennID = reader.GetString(3),
                                Verein = reader.GetString(4),
                                Steuerling = GetNameByID(reader.GetInt32(5)),
                                Athlet1 = GetNameByID(reader.GetInt32(6)),
                                Athlet2 = GetNameByID(reader.GetInt32(7)),
                                Athlet3 = GetNameByID(reader.GetInt32(8)),
                                Athlet4 = GetNameByID(reader.GetInt32(9)),
                                Athlet5 = GetNameByID(reader.GetInt32(10)),
                                Athlet6 = GetNameByID(reader.GetInt32(11)),
                                Athlet7 = GetNameByID(reader.GetInt32(12)),
                                Athlet8 = GetNameByID(reader.GetInt32(13)),
                                Meldername = reader.GetString(14),
                                Melderadresse = reader.GetString(15),
                                Melderort = reader.GetString(16),
                                Melderverein = reader.GetString(17),
                                Melderemail = reader.GetString(18),
                                Meldertel = reader.GetString(19),
                                Melderfax = reader.GetString(20),
                                Bezahlt = reader.GetDecimal(21),
                                ZuZahlen = reader.GetDecimal(22),
                                Bootsname = reader.GetString(23)
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
            string GetAllBoatDataQuery = "select BootsID, Abteilung, Startnummer, "
                        + "RennID, GesammtVerein, SteuerlingID, Athlet1ID, Athlet2ID, "
                        + "Athlet3ID, Athlet4ID, Athlet5ID, Athlet6ID, Athlet7ID, Athlet8ID, Meldername, "
                        + "Melderadresse, Melderort, Melderverein, Melderemail, Meldertel, Melderfax, "
                        + "Bezahlt, ZuZahlen, Bootsname from Boote where GesammtVerein = '" + verein + "';";
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
                            Boot boot = new Boot
                            {
                                BootsID = reader.GetInt32(0),
                                Abteilung = reader.GetInt32(1),
                                Startnummer = reader.GetInt32(2),
                                RennID = reader.GetString(3),
                                Verein = reader.GetString(4),
                                Steuerling = GetNameByID(reader.GetInt32(5)),
                                Athlet1 = GetNameByID(reader.GetInt32(6)),
                                Athlet2 = GetNameByID(reader.GetInt32(7)),
                                Athlet3 = GetNameByID(reader.GetInt32(8)),
                                Athlet4 = GetNameByID(reader.GetInt32(9)),
                                Athlet5 = GetNameByID(reader.GetInt32(10)),
                                Athlet6 = GetNameByID(reader.GetInt32(11)),
                                Athlet7 = GetNameByID(reader.GetInt32(12)),
                                Athlet8 = GetNameByID(reader.GetInt32(13)),
                                Meldername = reader.GetString(14),
                                Melderadresse = reader.GetString(15),
                                Melderort = reader.GetString(16),
                                Melderverein = reader.GetString(17),
                                Melderemail = reader.GetString(18),
                                Meldertel = reader.GetString(19),
                                Melderfax = reader.GetString(20),
                                Bezahlt = reader.GetDecimal(21),
                                ZuZahlen = reader.GetDecimal(22),
                                Bootsname = reader.GetString(23)
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
            const string GetAllVereineDataQuery = "SELECT GesammtVerein, count(GesammtVerein) AS anzahlBoote, "
                        + "sum(bezahlt) as bisherGesammtBezahlt, sum(zuZahlen) as gesammtZuZahlen, "
                        + "sum(bezahlt) - sum(zuZahlen) as total FROM Boote GROUP BY GesammtVerein order by count(GesammtVerein) DESC, GesammtVerein ASC";
            var vereine = new ObservableCollection<Verein>();
            Debug.WriteLine(GetAllVereineDataQuery);
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
                            Verein vereintmp = new Verein
                            {
                                Vereinsname = reader.GetString(0),
                                AnzahlBoote = reader.GetInt32(1),
                                BisherGesammtBezahlt = reader.GetDecimal(2),
                                GesammtZuZahlen = reader.GetDecimal(3),
                                Total = reader.GetDecimal(4)
                            };
                            vereintmp.Imp_BoolBezahlt = vereintmp.BisherGesammtBezahlt >= vereintmp.GesammtZuZahlen;
                            vereintmp.BoolBezahlt = vereintmp.Imp_BoolBezahlt;

                            vereintmp.VereinsBoote = GetBooteByVereinVereinssuche(vereintmp.Vereinsname);

                            vereine.Add(vereintmp);
                        }
                    }
                }
            }
            return vereine;
        }

        public static ObservableCollection<Verein> GetVereineVereinssuche(bool hatBezahlt)
        {
            string GetAllVereineDataQuery = "SELECT GesammtVerein, count(GesammtVerein) AS anzahlBoote, "
                        + "sum(bezahlt) as bisherGesammtBezahlt, sum(zuZahlen) as gesammtZuZahlen, "
                        + "sum(bezahlt) - sum(zuZahlen) as total FROM Boote GROUP BY GesammtVerein order by count(verein) DESC, GesammtVerein ASC";
            if (hatBezahlt)
            {
                GetAllVereineDataQuery += " WHERE sum(bezahlt) >= sum(zuZahlen);";
            }
            else
            {
                GetAllVereineDataQuery += " WHERE sum(zuZahlen) > sum(bezahlt);";
            }
            Debug.WriteLine(GetAllVereineDataQuery);
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
                            Verein vereintmp = new Verein
                            {
                                Vereinsname = reader.GetString(0),
                                AnzahlBoote = reader.GetInt32(1),
                                BisherGesammtBezahlt = reader.GetDecimal(2),
                                GesammtZuZahlen = reader.GetDecimal(3),
                                Total = reader.GetDecimal(4)
                            };
                            vereintmp.Imp_BoolBezahlt = vereintmp.BisherGesammtBezahlt >= vereintmp.GesammtZuZahlen;
                            vereintmp.BoolBezahlt = vereintmp.Imp_BoolBezahlt;

                            vereintmp.VereinsBoote = GetBooteByVereinVereinssuche(vereintmp.Vereinsname);

                            vereine.Add(vereintmp);
                        }
                    }
                }
            }
            return vereine;
        }

        public static ObservableCollection<Rennen> GetRennKonflikte()
        {
            var abteilungen = new ObservableCollection<Rennen>();
            const string GetAllVereineDataQuery = "SELECT Boote.RennID, count(Boote.RennID) AS AnzahlBoote, Boote.Abteilung as Abteilung, RennenLookuptable.Bezeichnung as Rennbezeichnung, RennenLookuptable.BootsTyp as BootsTyp "
                + "FROM Boote "
                + "JOIN RennenLookuptable ON RennenLookuptable.RennNr = Boote.RennID "
                + "GROUP BY Boote.RennID order by Boote.Abteilung ASC, RennenLookuptable.ROWID ASC;";
            Debug.WriteLine(GetAllVereineDataQuery);
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
                            Rennen rennentmp = new Rennen
                            {
                                RennID = reader.GetString(0),
                                AnzahlBoote = reader.GetInt32(1),
                                Abteilung = reader.GetInt32(2),
                                Rennbezeichnung = reader.GetString(3),
                                Bootstyp = reader.GetString(4)
                            };

                            abteilungen.Add(rennentmp);
                        }
                    }
                }
            }
            return abteilungen;
        }


    }
}