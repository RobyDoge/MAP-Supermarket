namespace Supermarket.Models.EntityLayer;

public class Producer: BasePropertyChanged
{
    #region Fields
    private int _id;
    private string? _name;
    private string? _originCountry;
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

    public string? Name
    {
        get => _name;
        set
        {
            _name = value;
            NotifyPropertyChanged("Name");
        }
    }

    public string? OriginCountry
    {
        get => _originCountry;
        set
        {
            _originCountry = value;
            NotifyPropertyChanged("OriginCountry");
        }
    }

    #endregion
}