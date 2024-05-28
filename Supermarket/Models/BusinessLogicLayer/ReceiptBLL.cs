using Supermarket.Models.DataAccessLayer;
using Supermarket.Services;

namespace Supermarket.Models.BusinessLogicLayer;

public class ReceiptBLL(string cashierName)
{
    private string CashierName { get; set; } = cashierName;
    private ReceiptDAL ReceiptDal { get; set; } = new();
    private ProductDAL ProductDal { get; set; } = new();
    private StockDAL StockDal { get; set; } = new();

    public void CreateReceipt(Dictionary<string, int> productList)
    {
        if (CashierName == null) throw new ArgumentNullException("CashierName is null");

        Dictionary<string, Tuple<int, decimal>> productPrices = new();
        foreach (var product in productList)
        {
            productPrices.Add(product.Key, new Tuple<int, decimal>(product.Value, ProductDal.GetProductPrice(product.Key)));
            //ai trebuie sa sterg si din stok cate produse am si daca ajung la 0 sa dezactivez stocul
            //si daca e singurul stok sa dezactivez si produsul
            StockDal.UpdateStock(product.Key, product.Value);
        }
        ShoppingListJson shoppingList = new(productPrices);
        ReceiptDal.CreateReceipt(CashierName, shoppingList.JsonList, shoppingList.TotalPrice);


    }
}