namespace Supermarket.Models.EntityLayer;

public class Stock:BasePropertyChanged
{
    #region Fields
    private int _id;
    private int _productId;
    private int? _quantity;
    private decimal? _purchasePurchasePrice;
    private decimal? _profitMargin;
    private DateTime? _purchaseDate;
    private DateTime? _expirationDate;
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

    public int ProductId
    {
        get => _productId;
        set
        {
            _productId = value;
            NotifyPropertyChanged("ProductId");
        }
    }

    public int? Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            NotifyPropertyChanged("Quantity");
        }
    }

    public decimal? PurchasePrice
    {
        get => _purchasePurchasePrice;
        set
        {
            _purchasePurchasePrice = value;
            NotifyPropertyChanged("PurchasePrice");
        }
    }

    public decimal? ProfitMargin
    {
        get => _profitMargin;
        set
        {
            _profitMargin = value;
            NotifyPropertyChanged("ProfitMargin");
        }
    }

    public DateTime? PurchaseDate
    {
        get => _purchaseDate;
        set
        {
            _purchaseDate = value;
            NotifyPropertyChanged("PurchaseDate");
        }
    }

    public DateTime? ExpirationDate
    {
        get => _expirationDate;
        set
        {
            _expirationDate = value;
            NotifyPropertyChanged("ExpirationDate");
        }
    }
    #endregion
    
}