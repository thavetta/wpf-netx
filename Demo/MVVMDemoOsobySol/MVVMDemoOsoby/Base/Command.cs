using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMStart.Base
{
    public class Command : ICommand
    {
        private Func<object?, bool>? canExecuteFunc;
        private Action<object?> executeFunc;

        public Command(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            this.executeFunc = execute;
            this.canExecuteFunc = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (canExecuteFunc != null)
                return canExecuteFunc(parameter);

            return true;
        }

        public void Execute(object? parameter)
        {
            executeFunc(parameter);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
