using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace App1
{
    public sealed partial class Konflikte : Page
    {
        private static int maxValue = 4;
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

        private void Go_Click(object _, Windows.UI.Xaml.RoutedEventArgs _1)
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
                    // generating the optimum array in mulitple Threads
                    Array optimalesArray = generateEval(rennKonflikte.Count);
                    //optimales Array ausgeben und in Datenbank schreiben

                }
            }
        }

        private Array generateEval(int rennAbteilungsAnzahl)
        {
            Random rtmp = new Random();
            double[] digit = new double[rennAbteilungsAnzahl];
            for (int i = digit.Length - 1; i >= 0; i--)
            {
                digit[i] = rtmp.Next(1, maxValue);
            }

            Extreme.Mathematics.Vector<double> initialGuess = Extreme.Mathematics.Vector.Create(digit);

            Func<Extreme.Mathematics.Vector<double>, double> f = evalFunctionfromVector;
            // Which method is used, is specified by a constructor
            // parameter of type QuasiNewtonMethod:
            var bfgs = new QuasiNewtonOptimizer(QuasiNewtonMethod.Bfgs);

            bfgs.InitialGuess = initialGuess;
            bfgs.ExtremumType = ExtremumType.Minimum;

            // Set the ObjectiveFunction:
            bfgs.ObjectiveFunction = f;
            // The FindExtremum method does all the hard work:
            bfgs.FindExtremum();

            Console.WriteLine("BFGS Method:");
            Console.WriteLine("  Solution: {0}", bfgs.Extremum);
            Console.WriteLine("  Estimated error: {0}", bfgs.EstimatedError);
            Console.WriteLine("  # iterations: {0}", bfgs.IterationsNeeded);
            // Optimizers return the number of function evaluations
            // and the number of gradient evaluations needed:
            Console.WriteLine("  # function evaluations: {0}", bfgs.EvaluationsNeeded);
            Console.WriteLine("  # gradient evaluations: {0}", bfgs.GradientEvaluationsNeeded);

            return digit;
        }

        private double evalFunctionfromVector(Extreme.Mathematics.Vector<double> x)
        {
            List<string>[] arrayListejeAbteilung = new List<string>[maxValue];
            for (int i = 0; i < x.Count; i++)
            {
                arrayListejeAbteilung[Convert.ToInt32(x.GetValue(i))].Add(konfliktRennID[i]);
            }
            int anzahlderKonflikte = 0;
            foreach (List<string> ltmp in arrayListejeAbteilung)
            {
                anzahlderKonflikte += DataAccess.AnzahlderKonflikte(ltmp);
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
