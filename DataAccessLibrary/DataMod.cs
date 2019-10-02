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

        /*
        public ObservableCollection<Tier1Kollision> GetTierOneKollisions()
        {
        var tierOneKollisionen = new ObservableCollection<Tier1Kollision>();
            const string GetTierOneKollisionsSQLString = "";

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
                            Rennen rennentmp = new Tier1Kollision
                            {
                                RennID = reader.GetString(0),
                                AnzahlBoote = reader.GetInt32(1),
                                Abteilung = reader.GetInt32(2),
                                Rennbezeichnung = reader.GetString(3),
                                Bootstyp = reader.GetString(4)
                            };

                            tierOneKollisionen.Add(rennentmp);
                        }
                    }
                }
            }
            return abteilungen;
        }*/
    }
}
