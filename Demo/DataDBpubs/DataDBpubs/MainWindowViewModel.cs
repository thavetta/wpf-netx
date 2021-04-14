using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataDBpubs.Context;
using DataDBpubs.Models;
using Microsoft.EntityFrameworkCore;

namespace DataDBpubs
{
    class MainWindowViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Job> Jobs { get; set; }
        public ObservableCollection<Publisher> Publishers { get; set; }

        public ICommand SaveCommand { get; set; }

        private PubsContext context = new PubsContext();

        public MainWindowViewModel()
        {
            context.Employees.Load();
            context.Publishers.Load();
            context.Jobs.Load();

            Employees = context.Employees.Local.ToObservableCollection();
            Jobs = context.Jobs.Local.ToObservableCollection();
            Publishers = context.Publishers.Local.ToObservableCollection();

            SaveCommand = new BaseCommand() { ExecuteAction = (x) => context.SaveChanges() };
        }
    }
}
