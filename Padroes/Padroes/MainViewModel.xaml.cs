using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Padroes
{
    /// <summary>
    /// Interaction logic for MainViewModel.xaml
    /// </summary>
    public partial class MainViewModel : Window
    {
        public MainViewModel()
        {
            InitializeComponent();

            Customer obj = new Customer();
            obj.CustomerName = "Maria";
            obj.Amount = 2000;
            obj.Married = "Married";

            CustomerViewModel viewModel = new CustomerViewModel(obj);

            DisplayUi(viewModel);
        }

        private void DisplayUi(CustomerViewModel o)
        {
            lblCustomerName.Content = o.txtCustomerName;
            lblSalesAmount.Content = o.txtAmount;
            BrushConverter brushconv = new BrushConverter();
            lblHabits.Background = brushconv.ConvertFromString(o.lblAmountColor) as SolidColorBrush;
            chkMarried.IsChecked = o.IsMarried;
        }
    }
}
