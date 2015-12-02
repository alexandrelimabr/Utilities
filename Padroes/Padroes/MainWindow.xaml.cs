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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Padroes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Customer obj = new Customer();
            obj.CustomerName = "Maria";
            obj.Amount = 2000;
            obj.Married = "Married";

            lblCustomerName.Content = obj.CustomerName; // mapping code
            lblSalesAmount.Content = obj.Amount; // mapping code

            if (obj.Amount > 2000) // transformation code
            {
                lblHabits.Background = new SolidColorBrush(Colors.Blue);
            }
            else if (obj.Amount > 1500) // transformation code
            {
                lblHabits.Background = new SolidColorBrush(Colors.Red);
            }
            if (obj.Married == "Married") // transformation code
            {
                chkMarried.IsChecked = true;
            }
            else
            {
                chkMarried.IsChecked = false;
            }
        }
    }
}
