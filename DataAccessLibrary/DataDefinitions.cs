using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Tier1Kollision : INotifyPropertyChanged
    {
        public int BootID1 { get; set; }
        public int BootID2 { get; set; }
        public string Name { get; set; }
        public string RennID { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

#pragma warning disable IDE0051 // Nicht verwendete private Member entfernen
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
#pragma warning restore IDE0051 // Nicht verwendete private Member entfernen
    }


    public class BootEditable : INotifyPropertyChanged
    {
        public int BootsID { get; set; }
        public int Abteilung { get; set; }
        public int Startnummer { get; set; }
        public string Rennbezeichnung { get; set; }
        public string RennID
        {
            get => Imp_RennID;
            set
            {
                if (Imp_RennID != value)
                {
                    Imp_RennID = value;
                    Rennen _tmp = DataAccess.RennenLookuptable_Query(value);
                    this.Bootstyp = _tmp.Bootstyp;
                    this.Rennbezeichnung = _tmp.Rennbezeichnung;
                    this.ZuZahlen = _tmp.ZuZahlen;
                    this.BoolBezahlt = this.ZuZahlen <= this.Bezahlt;
                    DataModification.UpdateBootEditable("RennID", value, this.BootsID);
                    DataModification.UpdateBootEditable("Bootstyp", _tmp.Bootstyp, this.BootsID);
                    DataModification.UpdateBootEditable("ZuZahlen", _tmp.ZuZahlen, this.BootsID);
                }
            }
        }
        public string Imp_RennID { get; set; }
        public string Bootsname
        {
            get => Imp_Bootsname;
            set
            {
                if (Imp_Bootsname != value)
                {
                    Imp_Bootsname = value;
                    DataModification.UpdateBootEditable("Bootsname", value, this.BootsID);
                }
            }
        }
        public string Imp_Bootsname { get; set; }
        public string Verein
        {
            get => Imp_Verein;
            set
            {
                if (Imp_Verein != value)
                {
                    Imp_Verein = value;
                    DataModification.UpdateBootEditable("Verein", value, this.BootsID);
                }
            }
        }
        public string Imp_Verein { get; set; }
        public string Steuerling { get; set; }
        public int SteuerlingID { get; set; }
        public string Athlet1 { get; set; }
        public int Athlet1ID { get; set; }
        public string Athlet2 { get; set; }
        public int Athlet2ID { get; set; }
        public string Athlet3 { get; set; }
        public int Athlet3ID { get; set; }
        public string Athlet4 { get; set; }
        public int Athlet4ID { get; set; }
        public string Athlet5 { get; set; }
        public int Athlet5ID { get; set; }
        public string Athlet6 { get; set; }
        public int Athlet6ID { get; set; }
        public string Athlet7 { get; set; }
        public int Athlet7ID { get; set; }
        public string Athlet8 { get; set; }
        public int Athlet8ID { get; set; }
        public string Meldername { get; set; }
        public string Melderadresse { get; set; }
        public string Melderort { get; set; }
        public string Melderverein { get; set; }
        public string Melderemail { get; set; }
        public string Meldertel { get; set; }
        public string Melderfax { get; set; }
        public decimal Bezahlt { get; set; }
        public decimal ZuZahlen { get; set; }
        public string Kommentare
        {
            get => Imp_Kommentare;
            set
            {
                if (Imp_Kommentare != value)
                {
                    Imp_Kommentare = value;
                    DataModification.UpdateBootEditable("Kommentare", value, this.BootsID);
                }
            }
        }
        public string Imp_Kommentare { get; set; }
        public string Bootstyp { get; set; }
        public bool BoolBezahlt
        {
            get => Imp_BoolBezahlt;
            set
            {
                if (Imp_BoolBezahlt != value)
                {
                    Imp_BoolBezahlt = value;
                    if (value)
                    {
                        DataModification.UpdateBootEditable("Bezahlt", this.ZuZahlen, this.BootsID);
                    }
                    else
                    {
                        DataModification.UpdateBootEditable("Bezahlt", 0, this.BootsID);
                    }
                }
            }
        }
        public bool Imp_BoolBezahlt { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

#pragma warning disable IDE0051 // Nicht verwendete private Member entfernen
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
#pragma warning restore IDE0051 // Nicht verwendete private Member entfernen
    }

    public class Rennen
    {
        public string RennID { get; set; }
        public string Rennbezeichnung { get; set; }
        public decimal ZuZahlen { get; set; }
        public string Bootstyp { get; set; }
        public int AnzahlBoote { get; set; }
        public int Abteilung { get; set; }
    }

    public class Boot : INotifyPropertyChanged
    {
        public int BootsID { get; set; }
        public int Abteilung { get; set; }

        public int Startnummer { get; set; }
        public string Rennbezeichnung { get; set; }
        public string Verein { get; set; }
        public string Steuerling { get; set; }
        public string Athlet1 { get; set; }
        public string Athlet2 { get; set; }
        public string Athlet3 { get; set; }
        public string Athlet4 { get; set; }
        public string Athlet5 { get; set; }
        public string Athlet6 { get; set; }
        public string Athlet7 { get; set; }
        public string Athlet8 { get; set; }
        public decimal Bezahlt { get; set; }
        public decimal ZuZahlen { get; set; }
        public string Meldername { get; set; }
        public string Melderadresse { get; set; }
        public string Melderort { get; set; }
        public string Melderverein { get; set; }
        public string Melderemail { get; set; }
        public string Meldertel { get; set; }
        public string Melderfax { get; set; }
        public string RennID { get; set; }
        public bool BoolBezahlt
        {
            get => Imp_BoolBezahlt;
            set
            {
                if (Imp_BoolBezahlt != value)
                {
                    Imp_BoolBezahlt = value;
                    if (value)
                    {
                        DataModification.UpdateBoot("Bezahlt", this.ZuZahlen, this.BootsID);
                    }
                    else
                    {
                        DataModification.UpdateBoot("Bezahlt", 0, this.BootsID);
                    }
                }
            }
        }
        public bool Imp_BoolBezahlt { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

#pragma warning disable IDE0051 // Nicht verwendete private Member entfernen
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
#pragma warning restore IDE0051 // Nicht verwendete private Member entfernen
    }

    public class Verein : INotifyPropertyChanged
    {
        public string Vereinsname { get; set; }
        public int AnzahlBoote { get; set; }
        public decimal BisherGesammtBezahlt { get; set; }
        public decimal GesammtZuZahlen { get; set; }
        public decimal Total { get; set; }
        public ObservableCollection<Boot> VereinsBoote { get; set; }
        public bool BoolBezahlt
        {
            get => Imp_BoolBezahlt;
            set
            {
                if (Imp_BoolBezahlt != value)
                {
                    Imp_BoolBezahlt = value;
                    DataModification.UpdateBootsBezahlstatus(VereinsBoote, value);
                }
            }
        }
        public bool Imp_BoolBezahlt { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

#pragma warning disable IDE0051 // Nicht verwendete private Member entfernen
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
#pragma warning restore IDE0051 // Nicht verwendete private Member entfernen
    }
}
