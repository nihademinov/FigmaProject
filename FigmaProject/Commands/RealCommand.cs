using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FigmaProject.Commands
{

    public class RealCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        { 
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public Predicate<object?>? _canExcecute;
        public Action<object?>? _execute;

        public RealCommand(Action<object?>? execute,Predicate<object?>? canExcecute = null)
        {
            _canExcecute = canExcecute;
            _execute = execute;
        }

        public bool CanExecute(object? parameter)
        {
            if(_canExcecute == null) return true;
            return _canExcecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
