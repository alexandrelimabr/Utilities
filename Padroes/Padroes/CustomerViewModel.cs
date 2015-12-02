using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padroes
{
    public class CustomerViewModel : INotifyPropertyChanged
    {

        private Customer obj = new Customer();
        private DelegateCommand objCommand;
    
        public event PropertyChangedEventHandler PropertyChanged;

        public CustomerViewModel()
        {
            objCommand = new DelegateCommand(Calculate, IsValid);

        }
        public CustomerViewModel(Customer customer)
        {
            obj = customer;
        }

        public System.Windows.Input.ICommand btnClick
        {
            get
            {
                return objCommand;
            }
        }

        public string txtCustomerName
        {
            get { return obj.CustomerName; }
            set { obj.CustomerName = value; }
        }
        public string txtAmount
        {
            get { return Convert.ToString(obj.Amount); }
            set { obj.Amount = Convert.ToDouble(value); }
        }
        public string lblAmountColor
        {
            get
            {
                if (obj.Amount > 2000)
                {
                    return "Blue";
                }
                else if (obj.Amount > 1500)
                {
                    return "Red";
                }
                return "Yellow";
            }
        }
        public bool IsMarried
        {
            get
            {
                if (obj.Married == "Married")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string Tax
        {
            get { return Convert.ToString(obj.Tax); }
            set { obj.Tax = Convert.ToDouble(value); }
        }

        public void Calculate()
        {
            obj.CalculateTax();

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Tax"));

            }
        }

        public bool IsValid()
        {
            if (obj.Amount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}