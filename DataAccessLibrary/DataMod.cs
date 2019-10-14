using Microsoft.Data.Sqlite;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DataAccessLibrary
{


    public static class DataModification
    {
        private static readonly String sqliteConnectionString = "Filename=boote.db";
        internal static void UpdateBootEditable(string zeilenName, object updateWert, int BootsID)
        {

            string UpdateOneBoatData =
                "UPDATE Boote "
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

        internal static void UpdateBootsBezahlstatus(ObservableCollection<Boot> vereinsBoote, bool boolBezahlt)
        {
            if (boolBezahlt)
            {
                foreach (Boot _tmp in vereinsBoote)
                {
                    UpdateBoot("Bezahlt", _tmp.ZuZahlen, _tmp.BootsID);
                }
            }
            else
            {
                foreach (Boot _tmp in vereinsBoote)
                {
                    UpdateBoot("Bezahlt", 0, _tmp.BootsID);
                }
            }
        }



        internal static void UpdateBoot(string zeilenName, object updateWert, int BootsID)
        {
            string UpdateOneBoatData = "UPDATE Boote "
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


        public static Collection<Tier1Kollision> GetTierOneKollisions()
        {
            var tierOneKollisionen = new ObservableCollection<Tier1Kollision>();
            const string GetTierOneKollisionsSQLString = "WITH tmp('BootsID', 'RennID', 'AthID') as ("
            + "SELECT BootsID, RennID, SteuerlingID "
            + "FROM Boote "
            + "UNION ALL "
            + "SELECT BootsID, RennID, Athlet1ID "
            + "FROM Boote "
            + "UNION ALL "
            + "SELECT BootsID, RennID, Athlet2ID "
            + "FROM Boote "
            + "UNION ALL "
            + "SELECT BootsID, RennID, Athlet3ID "
            + "FROM Boote "
            + "UNION ALL "
            + "SELECT BootsID, RennID, Athlet4ID "
            + "FROM Boote "
            + "UNION ALL "
            + "SELECT BootsID, RennID, Athlet5ID "
            + "FROM Boote "
            + "UNION ALL "
            + "SELECT BootsID, RennID, Athlet6ID "
            + "FROM Boote "
            + "UNION ALL "
            + "SELECT BootsID, RennID, Athlet7ID "
            + "FROM Boote "
            + "UNION ALL "
            + "SELECT BootsID, RennID, Athlet8ID "
            + "FROM Boote "
            + ") "

            + "SELECT tmp.BootsID, tmp.RennID, Personen.Name, Personen.Verein "
            + "FROM tmp "
            + "JOIN Personen On tmp.AthID = Personen.ROWID "
            + "WHERE(RennID, AthID) IN "
            + "(SELECT RennID, AthID FROM tmp "
            + "GROUP BY RennID, AthID "
            + "HAVING count(*) > 1 ORDER by AthID)";
            Debug.WriteLine(GetTierOneKollisionsSQLString);
            using (SqliteConnection conn = new SqliteConnection(sqliteConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = GetTierOneKollisionsSQLString;
                    conn.Open();
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tier1Kollision konflikttmp = new Tier1Kollision
                            {
                                BootID = reader.GetInt32(0),
                                RennID = reader.GetString(1),
                                Name = reader.GetString(2),
                                Verein = reader.GetString(3)
                            };

                            tierOneKollisionen.Add(konflikttmp);
                        }
                    }
                }
            }
            return tierOneKollisionen;
        }
    }
}
