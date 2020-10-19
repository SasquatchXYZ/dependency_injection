using System;
using System.Windows.Input;

namespace ProductManagement.PresentationLogic.UICommands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;

        public RelayCommand(Action execute)
        {
            _execute = parameter => execute();
        }

        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        public virtual void Execute(object paramter) => _execute(paramter);
    }
}