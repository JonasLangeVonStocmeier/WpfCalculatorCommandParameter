using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp42
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void RaisePropertyChange([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            }
        }
    }
}
