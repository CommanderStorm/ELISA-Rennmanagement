using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;

namespace App1
{
    public sealed partial class Konflikte : Page
    {
        private static int maxValue = 3;
        private string[] konfliktRennID;
        public Konflikte()
        {
            this.InitializeComponent();
            ObservableCollection<Rennen> _rtmp = DataAccess.GetRennKonflikte();
            dataGrid.ItemsSource = _rtmp;
            List<string> _konfliktRennID = new List<string>();
            foreach (Rennen r in _rtmp)
            {
                _konfliktRennID.Add(r.RennID);
            }
            konfliktRennID = _konfliktRennID.ToArray();
        }

        private void Go_ClickAsync(object _, Windows.UI.Xaml.RoutedEventArgs _1)
        {
            ObservableCollection<Rennen> rennKonflikte = DataAccess.GetRennKonflikte();
            //rule out an empty database
            if (rennKonflikte.Count < 3)
            {
                if (rennKonflikte.Count == 0)
                {
                    PopUP("Daten wurden noch nicht importiert", "Mann kann ohne Daten leider keine Aussagen ohne Daten treffen.", "OK, ich werde Daten importiernen");
                }
                else
                {
                    PopUP("Unter 3 Meldungsabteilungen???", "Für so wenige Kategorien ist das Programm nicht desight", "Ok...");
                }
            }
            else
            {

                //rule out TierOneKollisions
                Collection<Tier1Kollision> tier1Kollisions = DataModification.GetTierOneKollisions();

                if (tier1Kollisions.Count > 0)
                {
                    string stmp = "BootsID\tRennID\tName\t\tVerein";
                    foreach (Tier1Kollision tier1Kollision in tier1Kollisions)
                    {
                        stmp += "\n" + tier1Kollision.RennID.ToString() + "\t" + tier1Kollision.BootID.ToString() + "\t" + tier1Kollision.Name + "\t" + tier1Kollision.Verein;
                    }
                    PopUP("Level 1 Kollision (Personen doppelt in einem Boot oder in einem Rennen)", stmp, "OK, ich werde die Namen ändern");
                }
                else
                {
                    //await GenerateTheBestCombination(rennKonflikte);
                    GenerateTheBestCombination(rennKonflikte);
                }
            }
        }

        private void GenerateTheBestCombination(ObservableCollection<Rennen> rennKonflikte)
        {
            List<int[]> results = new List<int[]>();
            //List<Task<int[]>> tasks = new List<Task<int[]>>();
            for (int index0 = 1; index0 <= maxValue; index0++)
            {
                for (int index1 = 1; index1 <= maxValue; index1++)
                {
                    // generating the optimum array in mulitple Threads
                    //tasks.Add(Task.Run(() => topGuess(index0, index1, rennKonflikte.Count)));
                    results.Add(topGuess(index0, index1, rennKonflikte.Count));
                }
            }
            //int[][] results = await Task.WhenAll(tasks);

            //eval all the top Dogs
            int[] bestGuess = results[0];
            int bestGuessCost = EvalFunctionfromArray(bestGuess);
            foreach (int[] tmp in results)
            {
                if (EvalFunctionfromArray(tmp) < bestGuessCost)
                {
                    bestGuess = tmp;
                    bestGuessCost = EvalFunctionfromArray(tmp);
                }
            }



            //optimales Array ausgeben und in Datenbank schreiben
        }

        private int[] topGuess(int index0, int index1, int rennKonflikteAnzahl)
        {
            //create topGuess
            int[] topGuess = new int[rennKonflikteAnzahl];
            int[] increment;

            //initialise 
            topGuess[0] = index0;
            topGuess[1] = index1;
            for (int i = topGuess.Length - 1; i > 1; i--)
            {
                topGuess[i] = 1;
            }
            int topGuessCost = EvalFunctionfromArray(topGuess);
            increment = topGuess;

            //while Loop
            while (increment[1] == index1)
            {
                //increment
                increment = IncrementArray(increment);
                //if increment is better replace the topGuess and its fitness
                if (EvalFunctionfromArray(increment) < topGuessCost)
                {
                    topGuess = increment;
                    topGuessCost = EvalFunctionfromArray(increment);

                    string debug = increment[0] + "-" + increment[1] + ": ";
                    foreach (int tmp in topGuess)
                    {
                        debug+=tmp.ToString();
                    }
                    debug +=" [Cost " + topGuessCost + "]";
                    Debug.WriteLine(debug);
                }
            }

            //Diagnostics
            return topGuess;
        }

        private int[] IncrementArray(int[] increment)
        {
            for (int i = increment.Length - 1; i >= 0; i--)
            {
                increment[i] += 1;
                if (increment[i] > maxValue)
                {
                    increment[i] = 1;
                }
                else
                {
                    break;
                    // This will break out of the for - loop and stop processing increments as everything just fit nicely and we don't have to update more previous increments
                }
            }
            return increment;
        }

        private int EvalFunctionfromArray(int[] x)
        {
            /*Debug.Write("\n\nx = [");
            foreach (int tmp in x)
            {
                Debug.Write(tmp.ToString());
            }
            Debug.Write("]\n");*/

            List<string>[] arrayListejeAbteilung = new List<string>[maxValue];
            for (int i = 0; i < maxValue; i++)
            {
                arrayListejeAbteilung[i] = new List<string>();
            }
            for (int i = 0; i < x.Length; i++)
            {
                arrayListejeAbteilung[x[i] - 1].Add(konfliktRennID[i].ToString());
            }
            /*Debug.Write("arrayListejeAbteilung:");
            foreach (List<string> tmp1 in arrayListejeAbteilung)
            {
                Debug.Write("\tListe = [");
                foreach (string s in tmp1)
                {
                    Debug.Write(s);
                }
                Debug.Write("]\n");
            }*/
            int anzahlderKonflikte = 0;
            foreach (List<string> ltmp in arrayListejeAbteilung)
            {
                if (ltmp.Count > 0)
                {
                    anzahlderKonflikte += DataAccess.AnzahlderKonflikte(ltmp);
                }
            }
            /*
            int rennbooteInLauf = 0;
            rennbooteInLauf += DataAccess.RennbooteInLauf(list[0]);
            rennbooteInLauf += DataAccess.RennbooteInLauf(list[1]);
            */
            return anzahlderKonflikte * 10000;
            // + rennbooteInLauf*10 + DataAccess.KinderInLauf1(list[0];
        }


        private async void PopUP(string title, string content, string closeingText)
        {
            ContentDialog popUp = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = closeingText
            };

            _ = await popUp.ShowAsync();
        }
    }
}
