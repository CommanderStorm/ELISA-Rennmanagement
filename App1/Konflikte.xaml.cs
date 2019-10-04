using DataAccessLibrary;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;


namespace App1
{
    public sealed partial class Konflikte : Page
    {
        public Konflikte()
        {
            this.InitializeComponent();
            dataGrid.ItemsSource = DataAccess.GetRennKonflikte();
        }

        private void Go_Click(object _, Windows.UI.Xaml.RoutedEventArgs _1)
        {
            ObservableCollection<Rennen> rennKonflikte = DataAccess.GetRennKonflikte();
            //rule out an empty database
            if (rennKonflikte.Count == 0)
            {
                PopUP("Daten wurden noch nicht importiert", "Mann kann ohne Daten leider keine Aussagen ohne Daten treffen.", "OK, ich werde Daten importiernen");
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
            }
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
