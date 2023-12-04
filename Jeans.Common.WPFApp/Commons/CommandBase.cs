using System;
using System.Windows.Input;

namespace Jeans.Common.WPFApp.Commons
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return RaiseCanExecuteChanged?.Invoke(parameter) ?? true;
        }

        public virtual void Execute(object parameter)
        {
            RaiseExecuteChanged?.Invoke(parameter);
        }

        public Func<object, bool> RaiseCanExecuteChanged { get; set; }

        public Action<object> RaiseExecuteChanged { get; set; }
    }
}
