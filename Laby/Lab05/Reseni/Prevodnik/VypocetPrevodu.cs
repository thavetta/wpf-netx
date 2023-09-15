using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prevodnik
{
    public class VypocetPrevodu : INotifyPropertyChanged
    {
        private double vstupniHodnota;
        public double VstupniHodnota 
        {
            get => vstupniHodnota;
            set
            {
                if (value == vstupniHodnota)
                    return;
                vstupniHodnota = value;
                OnPropertyChanged(nameof(VstupniHodnota));
                Vypocet();
            }
        }

        private double vystupniHodnota;

        public double VystupniHodnota
        {
            get => vystupniHodnota;
            set
            {
                if (value == vystupniHodnota)
                    return;
                vystupniHodnota = value;
                OnPropertyChanged(nameof(VystupniHodnota));
            }
        }

        public Func<double,double> Prevod { get; set; }

        public void Vypocet()
        {
            VystupniHodnota = Prevod?.Invoke(VstupniHodnota) ?? 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
