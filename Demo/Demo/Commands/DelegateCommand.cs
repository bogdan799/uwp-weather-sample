using System;
using System.Windows.Input;

namespace Demo.Commands
{
    public sealed class DelegateCommand : ICommand
    {
        private readonly Action<Object> _executed;
        private readonly Func<Object, Boolean> _canExecute;
        
        public DelegateCommand(Action<Object> executed)
            : this(executed, null)
        {
        }

        public DelegateCommand(Action<Object> executed, Func<Object, Boolean> canExecute)
        {
            _executed = executed;
            _canExecute = canExecute;
        }

        public Boolean CanExecute(Object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(Object parameter)
        {
            _executed(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
