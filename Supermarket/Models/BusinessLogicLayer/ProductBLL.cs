using System;
using System.Collections.ObjectModel;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.Services;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class ProductBLL : BasePropertyChanged
    {
        private ProductDAL ProductDal { get; set; } = new();
        public ObservableCollection<string> FoundProducts = [];
        public ObservableCollection<string> FoundProductInfo = [];
        public string? CashierName { get; set; }
        public ProductBLL()
        {

        }
        public ProductBLL(string cashierName)
        {
            CashierName = cashierName;
        }

        public void SearchProducts(Tuple<string, string> searchInfo)
        {
            switch (searchInfo.Item1)
            {
                case "name":
                    FoundProducts = ProductDal.SearchProductsByName(searchInfo.Item2);
                    break;
                case "barcode":
                    FoundProducts = ProductDal.SearchProductsByBarcode(searchInfo.Item2);
                    break;
                case "expiration_date":
                    FoundProducts = ProductDal.SearchProductsByExpirationDate(searchInfo.Item2);
                    break;
                case "producer":
                    FoundProducts = ProductDal.SearchProductsByProducer(searchInfo.Item2);
                    break;
                case "category":
                    FoundProducts = ProductDal.SearchProductsByCategory(searchInfo.Item2);
                    break;
            }
        }

        public void GetProductInfo(string productName)
        {
            FoundProductInfo = ProductDal.GetProductInfo(productName);
        }

        public void SearchProducts(string notUsed)
        {
            if (SearchedText == null) return;
            FoundProducts = ProductDal.SearchProductsByName(SearchedText);
        }

        public void CheckStock(Tuple<string, int> obj)
        {
            EnoughStock = ProductDal.CheckStock(obj.Item1, obj.Item2);
        }

        public void CreateReceipt(Dictionary<string, int> productList)
        {
            if (CashierName == null) throw new ArgumentNullException("CashierName is null");

            Dictionary<string, Tuple<int,decimal>> productPrices = new();
            foreach (var product in productList)
            {
                productPrices.Add(product.Key, new Tuple<int, decimal>(product.Value,ProductDal.GetProductPrice(product.Key)));
            }
            ShoppingListJson shoppingList = new(productPrices);
            ProductDal.CreateReceipt(CashierName, shoppingList.JsonList,shoppingList.TotalPrice);

            
        }




        #region Fields

        private string? _searchedText;

        public string? SearchedText
        {
            get => _searchedText;
            set
            {
                _searchedText = value;
                NotifyPropertyChanged("SearchedText");
            }
        }

        private bool _enoughStock;

        public bool EnoughStock
        {
            get => _enoughStock;
            set
            {
                _enoughStock = value;
                NotifyPropertyChanged("SearchedText");
            }
        }

        #endregion


    }
}

