using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Supermarket.Models.EntityLayer;
using Supermarket.ViewModels;

namespace Supermarket.Views
{
    /// <summary>
    /// Interaction logic for CashierWindow.xaml
    /// </summary>
    public partial class CashierWindow : Window
    {
        ObservableCollection<Receipt> Receipts = new();
        private string CashierName { get; set; }
        public CashierWindow(string cashierName)
        {
            InitializeComponent();
            CashierName = cashierName;
            LoadReceipts();

        }

        private void LoadReceipts()
        {
            ReceiptVM receiptVm = new();
            receiptVm.LoadReceipts.Execute("");
            foreach (var receipt in receiptVm.Receipts)
            {
                cmbReceipt.Items.Add(receipt.Id);
            }
            Receipts = receiptVm.Receipts;
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

        private void CmbReceipt_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Receipt selectedReceipt = Receipts.FirstOrDefault(receipt => receipt.Id == (int)cmbReceipt.SelectedItem);
            if (selectedReceipt != null)
            {
                ReceiptInfoWindow receiptInfoWindow = new(selectedReceipt, CashierName);
                receiptInfoWindow.Show();
                Close();
            }
            
        }
    }
}
