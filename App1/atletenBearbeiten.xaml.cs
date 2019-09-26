﻿using DataAccessLibrary;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Threading.Tasks;

namespace App1
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class AtletenBearbeiten : Page
    {
        public AtletenBearbeiten()
        {
            this.InitializeComponent();
            _ = LoadAsync();
        }

        public async Task LoadAsync()
        {
            LoadingControl.IsLoading = true;
            this.FindName("dataGrid");
            dataGrid.ItemsSource = await Task.Run(() => DataAccess.GetImportdatenBearbeiten());
            LoadingControl.IsLoading = false;
        }

        private void FilterAbteilung1_Click(object _, RoutedEventArgs _1)
        {
            dataGrid.ItemsSource = DataAccess.GetImportdatenBearbeiten(1);
        }

        private void FilterAbteilung2_Click(object _, RoutedEventArgs _1)
        {
            dataGrid.ItemsSource = DataAccess.GetImportdatenBearbeiten(2);
        }

        private void FilterAbteilung3_Click(object _, RoutedEventArgs _1)
        {
            dataGrid.ItemsSource = DataAccess.GetImportdatenBearbeiten(3);
        }

        private void FilterAbteilung4_Click(object _, RoutedEventArgs _1)
        {
            dataGrid.ItemsSource = DataAccess.GetImportdatenBearbeiten(4);
        }

        private void ClearFilterAbteilung_Click(object _, RoutedEventArgs _1)
        {
            dataGrid.ItemsSource = DataAccess.GetImportdatenBearbeiten();
        }

        private void FilterNurMitKommentar_Click(object _, RoutedEventArgs _1)
        {
            dataGrid.ItemsSource = DataAccess.GetImportdatenBearbeiten(true);
        }

        private void Searchbox_TextChanged(object _, TextChangedEventArgs _1)
        {
            String searchstring = searchbox.Text.ToLower();
            if (searchstring == "")
            {
                dataGrid.ItemsSource = DataAccess.GetBooteBootssuche();
            }
            else
            {
                ObservableCollection<BootsImport> bootsanzeige_neu = new ObservableCollection<BootsImport>();
                foreach (BootsImport boot_under_search_Review in dataGrid.ItemsSource)
                {
                    if (searchstring.Contains(boot_under_search_Review.Startnummer.ToString()) || boot_under_search_Review.Verein.ToLower().Contains(searchstring) || boot_under_search_Review.Steuerling.ToLower().Contains(searchstring) || boot_under_search_Review.Athlet1.ToLower().Contains(searchstring) || boot_under_search_Review.Athlet2.ToLower().Contains(searchstring) || boot_under_search_Review.Athlet3.ToLower().Contains(searchstring) || boot_under_search_Review.Athlet4.ToLower().Contains(searchstring) || boot_under_search_Review.Athlet5.ToLower().Contains(searchstring) || boot_under_search_Review.Athlet6.ToLower().Contains(searchstring) || boot_under_search_Review.Athlet7.ToLower().Contains(searchstring) || boot_under_search_Review.Athlet8.ToLower().Contains(searchstring))
                    {
                        bootsanzeige_neu.Add(boot_under_search_Review);
                    }
                }
                dataGrid.ItemsSource = bootsanzeige_neu;
            }
        }
    }
}
