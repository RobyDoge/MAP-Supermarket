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

namespace Supermarket.Views
{
    /// <summary>
    /// Interaction logic for CashierWindow.xaml
    /// </summary>
    public partial class CashierWindow : Window
    {
        private string CashierName { get; set; }
        public CashierWindow(string cashierName)
        {
            InitializeComponent();
            CashierName = cashierName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new();
            loginWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ReceiptWindow receiptWindow = new (CashierName);
                receiptWindow.Show();
                Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new(false,CashierName);
            searchWindow.Show();
            Close();
        }
    }
}
