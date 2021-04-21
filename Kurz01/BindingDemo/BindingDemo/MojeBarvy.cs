using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingDemo
{
    class MojeBarvy : INotifyPropertyChanged
    {
        private string barvaPisma;

        public string BarvaPisma
        {
            get => barvaPisma; 
            set 
            { 
                if (barvaPisma == value)
                    return;
                barvaPisma = value;
                OnPropertyChanged(nameof(BarvaPisma));
            }
        }

        private string barvaPozadi;

        public string BarvaPozadi
        {
            get => barvaPozadi; 
            set
            {
                if (barvaPozadi == value)
                    return;
                barvaPozadi = value;
                OnPropertyChanged(nameof(BarvaPozadi));
            }
        }

        private int cislo;

        public int Cislo
        {
            get { return cislo; }
            set
            {
                if (cislo == value)
                    return;
                cislo = value;
                OnPropertyChanged(nameof(Cislo));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
