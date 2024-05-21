namespace Supermarket.Models.EntityLayer;

public class User : BasePropertyChanged
{
    #region Fields
    private int _id;
    private string? _name;
    private string? _password;
    private bool? _isAdmin;
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
    public string? Password
    {
        get => _password;
        set
        {
            _password = value;
            NotifyPropertyChanged("Password");
        }
    }
    public bool? IsAdmin
    {
                get => _isAdmin;
                set
                {
            _isAdmin = value;
            NotifyPropertyChanged("IsAdmin");
        }
    }
    
    #endregion
}