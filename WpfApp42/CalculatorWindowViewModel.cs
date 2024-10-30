using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp42
{
    public class CalculatorWindowViewModel : BaseViewModel
    {
        double lastValue;
        string operatorToExecute;
        public CalculatorWindowViewModel()
        {
            this.NumberCommand = new DelegateCommand((value) =>
            {
                int val = int.Parse((string)value);
                this.CurrentValue = this.CurrentValue * 10 + val;
            });
            this.OperatorCommand = new DelegateCommand(ExecuteOperation);
        }

        void ExecuteOperation(object o)
        {
            string op = (string)o;
            if (op == "=")
            {
                switch (operatorToExecute)
                {
                    case "+":
                        CurrentValue += lastValue;
                        break;
                    case "-":
                        CurrentValue = lastValue - currValue;
                        break;
                    case "*":
                        CurrentValue *= lastValue;
                        break;
                    case "/":
                        CurrentValue = lastValue / currValue;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                this.operatorToExecute = op;
                lastValue = currValue;
                CurrentValue = 0.0;


            }

        }
        double currValue;
        public double CurrentValue
        {
            get => currValue;
            set
            {
                if (currValue != value)
                {
                    currValue = value;
                    this.RaisePropertyChange();
                }
            }
        }

        public DelegateCommand NumberCommand { get; set; }
        public DelegateCommand OperatorCommand { get; set; }
    }
}
