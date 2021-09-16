using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMStart.Base;
using MVVMStart.Models;
using MVVMStart.ViewModels;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;


namespace MVVMStart
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            foreach (var osoba in Data.DataSource.GetListOsob())
            {
                SeznamOsob.Add(osoba);
            }

            SaveOsoba = new Command((o)=>
                { MessageBox.Show("SAVE"); ViewModel?.Save(); });
        }

        private Osoba? vybranaOsoba;

        public Osoba? VybranaOsoba
        {
            get => vybranaOsoba;
            set
            {
                if (vybranaOsoba != value)
                {
                    if (value != null)
                    {
                        ViewModel = new OsobaViewModel(value);
                    }
                    vybranaOsoba = value;
                    OnPropertyChanged(nameof(VybranaOsoba));
                }
            }
        }

        public ObservableCollection<Osoba> SeznamOsob { get; } = new ObservableCollection<Osoba>();

        private ViewModelBase? viewModel;

        public ViewModelBase? ViewModel
        {
            get => viewModel;
            set
            {
                if (viewModel != value)
                {
                    viewModel = value;
                    OnPropertyChanged(nameof(ViewModel));
                }
            }
        }

        public ICommand SaveOsoba { get; private set; }
    }
}
