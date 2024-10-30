using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp42
{
    public class DelegateCommand : ICommand
    {

        readonly Action<object> execute;

        readonly Predicate<object> canExetute;

        public DelegateCommand(Predicate<object> canExecute, Action<object> execute) => (this.canExetute, this.execute) = (canExetute, execute);
        public DelegateCommand(Action<object> execute) : this(null, execute)
        {
            
        }

        public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => this.canExetute?.Invoke(parameter) ?? true;

        public void Execute(object? parameter) => this.execute?.Invoke(parameter);
    }
}
