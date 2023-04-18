using System;
using System.Windows.Input;

namespace AviaPassangerViewer.MVVM.Base
{
    internal sealed class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public event CanExecuteActionEventHandler CanExecuteAction;
        public delegate bool CanExecuteActionEventHandler(object parameter = null);
        public bool CanExecute(object parameter = null) => CanExecuteAction?.Invoke(parameter) ?? true;

        public event ExecutableActionEventHandler ExecutableAction;
        public delegate void ExecutableActionEventHandler(object parameter = null);
        public void Execute(object parameter = null) => ExecutableAction?.Invoke(parameter);
    }
}
