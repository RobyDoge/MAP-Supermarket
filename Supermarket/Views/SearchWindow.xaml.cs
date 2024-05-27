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
using Supermarket.ViewModels;

namespace Supermarket.Views
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        SearchVM SearchVm = new();
        private bool IsAdmin { get; set; }
        ObservableCollection<string>? SearchBy { get; set; }
        private string CashierName { get; set; }

        public SearchWindow(bool isAdmin,string cashierName)
        {
            CashierName= cashierName;
            InitializeComponent();
            IsAdmin = isAdmin;
            CreateSearchBy();

        }

        private void CreateSearchBy()
        {
            SearchBy =
            [
                "Product Name",
                "Product Barcode",
                "Category",
                "Producer",
                "Expiration Date"
            ];
            if (SearchBy != null) cmbSearchBy.ItemsSource = SearchBy;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (IsAdmin)
            {
                AdminWindow adminWindow = new();
                adminWindow.Show();
                Close();
            }
            else
            {
                CashierWindow cashierWindow = new(CashierName);
                cashierWindow.Show();
                Close();
            }
        }

        private void CmbSearchBy_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchVm.SelectedSearchBy = cmbSearchBy.SelectedIndex switch
            {
                0 => "name",
                1 => "barcode",
                2 => "category",
                3 => "producer",
                4 => "expiration_date",
                _ => "name"
            };
        }

        private void txtSearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchInfo = Tuple.Create(SearchVm.SelectedSearchBy.ToString(), txtSearchBar.Text);
            SearchVm.SearchCommand.Execute(searchInfo);
            lbFoundItems.ItemsSource = SearchVm.ReturnedItems;

        }

        private void LbFoundItems_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = lbFoundItems.SelectedItem;

            SearchVm.GetProductInfo.Execute(selectedItem);

            ProductInfo productInfo = new(SearchVm.ReturnedProductInfo);
            productInfo.Show();

        }
    }
}
