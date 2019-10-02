﻿using DataAccessLibrary;
using Windows.UI.Xaml.Controls;


namespace App1
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class Konflikte : Page
    {
        public Konflikte()
        {
            this.InitializeComponent();
            dataGrid.ItemsSource = DataAccess.GetRennKonflikte();
        }

        private void Go_Click(object _, Windows.UI.Xaml.RoutedEventArgs _1)
        {

        }
    }
}
