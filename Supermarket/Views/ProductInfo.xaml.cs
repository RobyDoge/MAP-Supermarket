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

namespace Supermarket.Views
{
    /// <summary>
    /// Interaction logic for ProductInfo.xaml
    /// </summary>
    public partial class ProductInfo : Window
    {
        public ObservableCollection<string> ProductInfoList { get; set; } = [];
        public ProductInfo(ObservableCollection<string> productInfo)
        {
            FormatList(productInfo);
            InitializeComponent();
            ListBox.ItemsSource = ProductInfoList;
        }

        public ProductInfo()
        {
            
        }

        private void FormatList(ObservableCollection<string> productInfo)
        {
            ProductInfoList.Add($"Product Name = {productInfo[0]}");
            ProductInfoList.Add($"Barcode = {productInfo[1]}");
            ProductInfoList.Add($"Category = {productInfo[2]}");
            ProductInfoList.Add($"Producer = {productInfo[3]}");
            ProductInfoList.Add($"Expiration Date = {productInfo[4]}");
            ProductInfoList.Add($"Price = ${productInfo[5]}");

        }
    }
}
