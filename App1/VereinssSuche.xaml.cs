using DataAccessLibrary;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace App1
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class VereinssSuche : Page
    {
        private ObservableCollection<Verein> vereinsanzeige = new ObservableCollection<Verein>();

        public VereinssSuche()
        {
            this.InitializeComponent();
            vereinsanzeige = DataAccess.GetVereineVereinssuche();
            Vereeinssearchlisting.ItemsSource = vereinsanzeige;
        }

        private void Searchbox_TextChanged(object _, TextChangedEventArgs _1)
        {
            String searchstring = searchbox.Text.ToLower();
            if (searchstring == "")
            {
                vereinsanzeige = DataAccess.GetVereineVereinssuche();
            }
            else
            {
                ObservableCollection<Verein> vereinsanzeige_neu = new ObservableCollection<Verein>();
                foreach (Verein verein_under_search_Review in DataAccess.GetVereineVereinssuche())
                {
                    if (searchstring.Contains(verein_under_search_Review.AnzahlBoote.ToString()) || verein_under_search_Review.Vereinsname.ToLower().Contains(searchstring))
                    {
                        vereinsanzeige_neu.Add(verein_under_search_Review);
                    }
                }
                vereinsanzeige = vereinsanzeige_neu;
            }
            Vereeinssearchlisting.ItemsSource = vereinsanzeige;
        }

        private void Vereeinssearchlisting_SelectionChanged(object _, SelectionChangedEventArgs _1)
        {
            //object vereintmp = Vereeinssearchlisting.SelectedItems.GetType();
            //Vereinsbootslisting.ItemsSource = DataAccess.GetBooteByVereinVereinssuche(vereintmp.verein);
            //searchbox.Text = vereintmp.ToString();
            //Verein tp = (Verein)Vereeinssearchlisting.SelectedItems;
            //Vereinsbootslisting.ItemsSource = tp.vereinsBoote;
        }
    }
}
