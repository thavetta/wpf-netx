using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataDBpubs
{
    class BaseCommand : ICommand
    {
        public Action<object> ExecuteAction;
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ExecuteAction?.Invoke(parameter);
        }

        public event EventHandler? CanExecuteChanged;
    }
}
