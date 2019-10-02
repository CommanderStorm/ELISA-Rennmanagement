using DataAccessLibrary;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;



namespace App1
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class VereinssSuche : Page
    {
        public VereinssSuche()
        {
            this.InitializeComponent();
            dataGrid.ItemsSource = DataAccess.GetVereineVereinssuche();
        }

        private void FilterBezahlt_Click(object _, RoutedEventArgs _1)
        {
            dataGrid.ItemsSource = DataAccess.GetVereineVereinssuche(true);
        }

        private void FilternichtBezahlt_Click(object _, RoutedEventArgs _1)
        {
            dataGrid.ItemsSource = DataAccess.GetVereineVereinssuche(false);
        }

        private void ClearFilter_Click(object _, RoutedEventArgs _1)
        {
            dataGrid.ItemsSource = DataAccess.GetVereineVereinssuche();
        }


        private void Searchbox_TextChanged(object _, TextChangedEventArgs _1)
        {
            String searchstring = searchbox.Text.ToLower();
            if (searchstring == "")
            {
                dataGrid.ItemsSource = DataAccess.GetVereineVereinssuche();
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
                dataGrid.ItemsSource = vereinsanzeige_neu;
            }
        }

    }
}