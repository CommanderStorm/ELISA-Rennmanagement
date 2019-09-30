using DataAccessLibrary;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace App1
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class Import : Page
    {
        public Import()
        {
            this.InitializeComponent();
        }

        public static string FirstCharToUpper(string s)
        {
            // Check for empty string.  
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.  
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }

        private string NamenLookup(ISheet sheet, string NachnameCellID, string VornameCellID)
        {
            return CellLookup(sheet, NachnameCellID).ToUpper() + ", " + FirstCharToUpper(CellLookup(sheet, VornameCellID));
        }

        private string CellLookup(ISheet sheet, string CellID)
        {
            string output;

            //get str from exel
            switch (CellID.ToCharArray()[0] + " ")
            {
                case "A ":
                    output = sheet.GetRow(Int32.Parse(CellID.Substring(1)) - 1).GetCell(0).ToString();
                    break;
                case "B ":
                    output = sheet.GetRow(Int32.Parse(CellID.Substring(1)) - 1).GetCell(1).ToString();
                    break;
                case "C ":
                    output = sheet.GetRow(Int32.Parse(CellID.Substring(1)) - 1).GetCell(2).ToString();
                    break;
                case "D ":
                    output = sheet.GetRow(Int32.Parse(CellID.Substring(1)) - 1).GetCell(3).ToString();
                    break;
                case "E ":
                    output = sheet.GetRow(Int32.Parse(CellID.Substring(1)) - 1).GetCell(4).ToString();
                    break;
                case "F ":
                    output = sheet.GetRow(Int32.Parse(CellID.Substring(1)) - 1).GetCell(5).ToString();
                    break;
                case "G ":
                    output = sheet.GetRow(Int32.Parse(CellID.Substring(1)) - 1).GetCell(6).ToString();
                    break;
                case "H ":
                    output = sheet.GetRow(Int32.Parse(CellID.Substring(1)) - 1).GetCell(7).ToString();
                    break;
                default:
                    Debug.WriteLine("Unreacheable State in CellLookup from" + CellID + "[Import.cs]");
                    output = "Unreacheable State in CellLookup from" + CellID + "[Import.cs]";
                    break;
            }

            //clear from quotes and dublequotes
            string Dublequote = "\"";
            output = output.Replace(Dublequote, string.Empty);
            string Singlequote = "\'";
            output = output.Replace(Singlequote, string.Empty);
            return output;
        }

        private async void DisplayImportwurdegestartet()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Der Import wurde gestart!",
                Content = "Das dauert leider etwas, habe deshalb bitte etwas Geduld.",
                CloseButtonText = "Ok"
            };
            _ = await noWifiDialog.ShowAsync();
        }

        private async void Durchsuchen_Click(object sender, RoutedEventArgs _1)
        {
            int BootsIDCounter = 1;
            int Filecounter = 1;
            var folderPicker = new Windows.Storage.Pickers.FolderPicker
            {
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop
            };
            folderPicker.FileTypeFilter.Add("*");

            Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                DataAccess.Reset();

                // Application now has read/write access to all contents in the picked folder
                // (including other sub-folder contents)
                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                DisplayImportwurdegestartet();
                IReadOnlyList<StorageFile> filelist = await folder.GetFilesAsync();
                FileImport_Progress_indicator.Maximum = filelist.Count;
                FileImport_Progress_indicator.Visibility = Visibility.Visible;
                foreach (StorageFile file in filelist)
                {

                    if (file.FileType == ".xls" || file.FileType == ".xlsx")
                    {
                        FileImport_success_indicator.Text += "Successfully processed " + file.DisplayName + " at " + file.Path + " (" + file.FileType + ")\n";
                        //Get Exel ready
                        ISheet sheet;
                        using (Stream filetmp = await file.OpenStreamForReadAsync())
                        {
                            if (file.FileType == ".xls")
                            {
                                HSSFWorkbook hssfwb;
                                hssfwb = new HSSFWorkbook(filetmp);
                                sheet = hssfwb.GetSheetAt(0);
                            }
                            else
                            {
                                XSSFWorkbook xssfwb;
                                xssfwb = new XSSFWorkbook(filetmp);
                                sheet = xssfwb.GetSheetAt(0);

                            }
                        }
                        //import Exel to DataAcccess
                        int BootsID = BootsIDCounter++;
                        string Rennbezeichnung = " [Ak " + CellLookup(sheet, "E12") + "]";
                        string RennID = CellLookup(sheet, "A12");
                        string Bootsname = CellLookup(sheet, "C26");
                        string Verein = CellLookup(sheet, "G12");
                        string Steuerling = NamenLookup(sheet, "D24", "C24");
                        string SteuerlingVerein = CellLookup(sheet, "G16");
                        string Athlet1 = NamenLookup(sheet, "D16", "C16");
                        string Athlet1Verein = CellLookup(sheet, "G16");
                        string Athlet2 = NamenLookup(sheet, "D17", "C17");
                        string Athlet2Verein = CellLookup(sheet, "G17");
                        string Athlet3 = NamenLookup(sheet, "D18", "C18");
                        string Athlet3Verein = CellLookup(sheet, "G18");
                        string Athlet4 = NamenLookup(sheet, "D19", "C19");
                        string Athlet4Verein = CellLookup(sheet, "G19");
                        string Athlet5 = NamenLookup(sheet, "D20", "C20");
                        string Athlet5Verein = CellLookup(sheet, "G20");
                        string Athlet6 = NamenLookup(sheet, "D21", "C21");
                        string Athlet6Verein = CellLookup(sheet, "G21");
                        string Athlet7 = NamenLookup(sheet, "D22", "C22");
                        string Athlet7Verein = CellLookup(sheet, "G22");
                        string Athlet8 = NamenLookup(sheet, "D23", "C23");
                        string Athlet8Verein = CellLookup(sheet, "G23");
                        string Meldername = NamenLookup(sheet, "G3", "D3");
                        string Melderadresse = FirstCharToUpper(CellLookup(sheet, "D4"));
                        string Melderort = CellLookup(sheet, "D5") + " " + FirstCharToUpper(CellLookup(sheet, "F5"));
                        string Melderverein = CellLookup(sheet, "D6");
                        string Melderemail = CellLookup(sheet, "D7").ToLower();
                        string Meldertel = CellLookup(sheet, "D8");
                        string Melderfax = CellLookup(sheet, "D9");
                        string Kommentare = CellLookup(sheet, "D27");
                        decimal Bezahlt = 0;

                        DataAccess.AddData(BootsID, 0, 0, Rennbezeichnung, RennID, Bootsname, Verein,
                            Steuerling, SteuerlingVerein, Athlet1, Athlet1Verein, Athlet2, Athlet2Verein,
                            Athlet3, Athlet3Verein, Athlet4, Athlet4Verein, Athlet5, Athlet5Verein,
                            Athlet6, Athlet6Verein, Athlet7, Athlet7Verein, Athlet8, Athlet8Verein,
                            Meldername, Melderadresse, Melderort, Melderverein, Melderemail,
                            Meldertel, Melderfax, Bezahlt, Kommentare);
                    }
                    else
                    {

                        FileImport_success_indicator.Text += "\nFataly failed to process " + file.DisplayName + " at " + file.Path + " (" + file.FileType + ")\n\n";
                    }
                    FileImport_Progress_indicator.Value = Filecounter++;
                }
                durchsuchen.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
            }
        }
    }
}

