using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MVVMStart.Base;

namespace MVVMStart.Models
{
    
    public class Osoba : Entita
    {
        

        private string meno = string.Empty;

        public string Meno
        {
            get => meno; 
            set
            {
                if (meno != value)
                {
                    meno = value;
                    OnPropertyChanged(nameof(Meno));
                }
            }
        }

        private string mesto = string.Empty;

        public string Mesto
        {
            get => mesto;
            set
            {
                if (mesto != value)
                {
                    mesto = value;
                    OnPropertyChanged(nameof(Mesto));
                }
            }
        }

       private DateTime datumNarozeni;

        public DateTime DatumNarozeni
        {
            get => datumNarozeni; 
            set
            {
                if (datumNarozeni != value)
                {
                    datumNarozeni = value;
                    OnPropertyChanged(nameof(DatumNarozeni));
                }
            }
        }

        private int pocetDeti;

        public int PocetDeti
        {
            get => pocetDeti; 
            set
            {
                if (pocetDeti != value)
                {
                    pocetDeti = value;
                    OnPropertyChanged(nameof(PocetDeti));
                }
            }
        }

        public override string ToString()
        {
            return Meno + " - " + Mesto;
        }
    }
}
