using System;
using System.Collections.ObjectModel;
using Supermarket.Models.DataAccessLayer;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class ProductBLL
    {
        private ProductDAL ProductDal { get; set; } = new();
        public ObservableCollection<string> FoundProducts = [];
        public ObservableCollection<string> FoundProductInfo = [];
        public void SearchProducts(Tuple<string, string> searchInfo )
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
    }
}
