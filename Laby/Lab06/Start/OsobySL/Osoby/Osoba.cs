using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Osoby
{
    public class Osoba : INotifyPropertyChanged
    {
        private string jmeno;

        public string Jmeno
        {
            get => jmeno;
            set
            {
                if (jmeno == value) return;
                jmeno = value;
                OnPropertyChanged(nameof(Jmeno));
                OnPropertyChanged(nameof(KompletJmeno));
            }
        }

        private string prijmeni;

        public string Prijmeni
        {
            get => prijmeni;
            set
            {
                if (prijmeni == value) return;
                prijmeni = value;
                OnPropertyChanged(nameof(Prijmeni));
                OnPropertyChanged(nameof(KompletJmeno));
            }
        }

        public string KompletJmeno => Jmeno + " " + Prijmeni;

        private string mesto;

        public string Mesto
        {
            get => mesto;
            set
            {
                if (mesto == value) return;
                mesto = value;
                OnPropertyChanged(nameof(Mesto));
            }
        }

        private int plat;

        public int Plat
        {
            get => plat;
            set
            {
                if (plat == value) return;
                plat = value;
                OnPropertyChanged(nameof(Plat));
            }
        }



        //Implementace INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
