using System;
using System.Collections.ObjectModel;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class ProductBLL : BasePropertyChanged
    {
        private ProductDAL ProductDal { get; set; } = new();
        public ObservableCollection<string> FoundProducts = [];
        public ObservableCollection<string> FoundProductInfo = [];

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
            EnoughStock = ProductDal.CheckStock(obj.Item1,obj.Item2);
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

