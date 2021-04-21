using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataDBpubs.Context;
using DataDBpubs.Models;
using Microsoft.EntityFrameworkCore;

namespace DataDBpubs 
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set
            {
                if (employees == value)
                    return;
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
        private ObservableCollection<Job> jobs;
        public ObservableCollection<Job> Jobs
        {
            get => jobs;
            set
            {
                if (jobs == value)
                    return;
                jobs = value;
                OnPropertyChanged(nameof(Jobs));
            }
        }
        private ObservableCollection<Publisher> publishers;
        public ObservableCollection<Publisher> Publishers
        {
            get => publishers;
            set
            {
                if (publishers == value)
                    return;
                publishers = value;
                OnPropertyChanged(nameof(Publishers));
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        private PubsContext context = new PubsContext();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainWindowViewModel()
        {
            LoadCommand = new BaseCommand()
            {
                ExecuteAction =
                (x) =>
                {
                    context.Employees.Load();
                    context.Publishers.Load();
                    context.Jobs.Load();

                    Employees = context.Employees.Local.ToObservableCollection();
                    Jobs = context.Jobs.Local.ToObservableCollection();
                    Publishers = context.Publishers.Local.ToObservableCollection();

                }
            };
            SaveCommand = new BaseCommand() { ExecuteAction = (x) => context.SaveChanges() };
        }
    }
}
