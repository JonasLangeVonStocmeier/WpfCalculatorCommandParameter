using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp42
{
    class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            this.ClearCommand = new DelegateCommand(
            (o) => !String.IsNullOrEmpty(Firstname) && !String.IsNullOrEmpty(Lastname),
            (o) => { this.Firstname = ""; this.Lastname = ""; }
            );
            Firstname = "dave";
            Lastname = "dev";

        }

        public DelegateCommand ClearCommand { get; set; }

        string firstname;
        //public string Firstname { get; set; }
        public string Firstname { 
            get => firstname;
            set {
                if (firstname != value)
                {
                    firstname = value;
                    this.RaisePropertyChange();
                    this.RaisePropertyChange(nameof(Fullname));
                    this.ClearCommand.RaiseCanExecuteChanged();
                }
            }
        }

        //public string Lastname { get; set; }
        string lastname;
        public string Lastname {
            get => lastname;
            set
            {
                if (lastname != value)
                {
                    lastname = value;
                    this.RaisePropertyChange();
                    this.RaisePropertyChange(nameof(Fullname));
                    this.ClearCommand.RaiseCanExecuteChanged();

                }
            }
        }


  


        public string Fullname => $"{Firstname} {Lastname}";

    }
}
