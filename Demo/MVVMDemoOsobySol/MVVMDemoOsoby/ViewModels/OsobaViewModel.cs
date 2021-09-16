using MVVMStart.Base;
using MVVMStart.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMStart.ViewModels
{
    public class OsobaViewModel : ViewModelBase
    {
        #region Model Properties

        private string meno = string.Empty;
        [Required]
        [StringLength(10)]
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

        private string mesto = String.Empty;
        [Required]
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
                if (pocetDeti == value)
                    return;
                
                pocetDeti = value;
                OnPropertyChanged(nameof(PocetDeti));
            }
        }

        #endregion

#region Konstruktor

        public OsobaViewModel(Osoba o)
        {
            NastavModel(o);
        }

        private void NastavModel(Osoba o)
        {
            this.mesto = o.Mesto;
            this.meno = o.Meno;
            this.datumNarozeni = o.DatumNarozeni;
            this.pocetDeti = o.PocetDeti;
            this.model = o;
        }
        #endregion

        private Osoba model = new Osoba();

        public void SaveOsoba()
        {
            this.model.Meno = this.Meno;
            this.model.Mesto = this.Mesto;
            this.model.DatumNarozeni = this.DatumNarozeni;
            this.model.PocetDeti = this.PocetDeti;
        }

        protected override void SaveInternal()
        {
            SaveOsoba();
        }

    }
}
