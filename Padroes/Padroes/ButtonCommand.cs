using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Padroes
{
    public class ButtonCommand : ICommand
    { 
        private Action WhatToExecute;
        private Func<bool> WhenToExecute;

        public event EventHandler CanExecuteChanged;

        public ButtonCommand(Action what, Func<bool> When)
        {
            this.WhenToExecute = When;
            this.WhatToExecute = what;
        }

        public bool CanExecute(object parameter)
        {
            return WhenToExecute();
        }

        public void Execute(object parameter)
        {
            WhatToExecute();
        }
    }
}
