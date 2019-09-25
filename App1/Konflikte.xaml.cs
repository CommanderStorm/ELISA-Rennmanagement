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
            dataGrid.
            dataGrid.ItemsSource = DataAccessLibrary.DataAccess.GetImportdatenBearbeiten();
        }

        private void go_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void ExportToSearch_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
