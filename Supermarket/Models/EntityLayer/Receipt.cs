using System.Text.Json;
using System.Text.Json.Serialization;

namespace Supermarket.Models.EntityLayer;

// wip
public class Receipt : BasePropertyChanged
{
    #region Fields

    private int _id;
    private int _cashierId;
    private decimal _total;
    private string? _productsJson;

    private List<Product> _productList;
    #endregion

    #region Properties

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            NotifyPropertyChanged("Id");
        }
    }

    public int CashierId
    {
        get => _cashierId;
        set
        {
            _cashierId = value;
            NotifyPropertyChanged("CashierId");
        }
    }

    public decimal Total
    {
        get => _total;
        set
        {
            _total = value;
            NotifyPropertyChanged("Total");
        }
    }

    public string? ProductsJson
    {
        get => _productsJson;
        set
        {
            _productsJson = value;
            NotifyPropertyChanged("ProductList");
        }
    }

    [JsonIgnore]
    public List<Product>? ProductList
    {
        get => string.IsNullOrEmpty(ProductsJson) ? null : JsonSerializer.Deserialize<List<Product>>(ProductsJson);
        set => ProductsJson = JsonSerializer.Serialize(value);
    }
    #endregion


    public abstract class ReceiptProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}