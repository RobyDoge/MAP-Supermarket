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
using Supermarket.Services;
using Supermarket.ViewModels;

namespace Supermarket.Views
{
    /// <summary>
    /// Interaction logic for ReceiptInfoWindow.xaml
    /// </summary>
    public partial class ReceiptInfoWindow : Window
    {
        private Receipt Receipt { get; set; }
        private string CashierName { get; set; }
        private ReceiptVM ReceiptVm { get; set; } = new();
        private ObservableCollection<string> ShoppingList { get; set; } = new();
        
        public ReceiptInfoWindow(Receipt receipt, string cashierName)
        {
            Receipt = receipt;
            InitializeComponent();
            CashierName = cashierName;
            ReceiptVm.GetCashierName.Execute(receipt.Id);
            lbCashierName.Content = ReceiptVm.ReceiptCashierName;
            lbTotalSum.Content = "$"+receipt.Total;
            CreateProductsList();
            libProductList.ItemsSource = ShoppingList;
        }

        private void CreateProductsList()
        {
            ShoppingListJson shoppingListJson = new(Receipt.ProductsJson);
            foreach (var product in shoppingListJson.ShoppingList)
            {
                var price =  product.Value.Item1*product.Value.Item2;
                ShoppingList.Add($"{product.Value.Item1} x {product.Key} - {price}");
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            CashierWindow cashierWindow = new(CashierName);
            cashierWindow.Show();
            Close();

        }
    }
}
