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
using Supermarket.ViewModels;

namespace Supermarket.Views
{
    /// <summary>
    /// Interaction logic for ReceiptWindow.xaml
    /// </summary>
    public partial class ReceiptWindow : Window
    {
        private ReceiptVM ReceiptVm = new();
        public ReceiptWindow()
        {
            InitializeComponent();
            DataContext = ReceiptVm;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            CashierWindow cashierWindow = new();
            cashierWindow.Show();
            Close();
            
        }

        private void txtSearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ReceiptVm.SearchedText= txtSearchBar.Text;
            ReceiptVm.SearchItems.Execute("notUsed");
            lbFoundItems.ItemsSource = ReceiptVm.FoundItems;
        }

        private void LbFoundItems_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Open a dialog to ask the user how many items they want to buy
            int quantity = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("How many items would you like to buy?", "Quantity", "0");

                isValidInput = int.TryParse(input, out quantity);

                if (!isValidInput)
                {
                    MessageBox.Show("Invalid input. Please enter a valid number.");
                }
            }

            ReceiptVm.CheckStock.Execute(new Tuple<string, int>(lbFoundItems.SelectedItems[0].ToString(), quantity));
            if (!ReceiptVm.EnoughStock)
            {
                MessageBox.Show("There is not enough stock for this item.");
                return;
            }
        }
    }
}
