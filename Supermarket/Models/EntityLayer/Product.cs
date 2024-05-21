namespace Supermarket.Models.EntityLayer;

public class Product: BasePropertyChanged
{
    #region Fields

    private int _id;
    private string? _name;
    private string? _barcode;
    private string? _category;
    private int _producerId;

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

    public string Name
    {
        get => _name!;
        set
        {
            _name = value;
            NotifyPropertyChanged("Name");
        }
    }

    public string Barcode
    {
        get => _barcode!;
        set
        {
            _barcode = value;
            NotifyPropertyChanged("Barcode");
        }
    }

    public string Category
    {
        get => _category!;
        set
        {
            _category = value;
            NotifyPropertyChanged("Category");
        }
    }

    public int ProducerId
    {
        get => _producerId;
        set
        {
            _producerId = value;
            NotifyPropertyChanged("ProfitMargin");
        }
    }


    #endregion
}