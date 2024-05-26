using System.Collections.ObjectModel;
using System.Windows.Input;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.ViewModels.Commands;

namespace Supermarket.ViewModels;

public class LoginVM
{
    UserBLL UserBll = new();


    public LoginVM()
    {
        Type = UserBll.Type;
    }

    #region DataMembers

    public ObservableCollection<string> LoginInfo { get; set; } = [];

    public ObservableCollection<string> Type
    {
        get => UserBll.Type;
        set => UserBll.Type = value;
    }

    #endregion

    #region Commands

    private ICommand _loginCommand;

    public ICommand LoginCommand
    {
        get
        {
            if (_loginCommand == null)
            {
                _loginCommand = new RelayCommand<ObservableCollection<string>>(UserBll.CheckLoginInfo);
            }
            return _loginCommand;
        }
    }
    private ICommand _registerCommand;

    public ICommand RegisterCommand
    {
        get
        {
            if (_registerCommand == null)
            {
                _registerCommand = new RelayCommand<ObservableCollection<string>>(UserBll.CreateUser);
            }
            return _registerCommand;
        }
    }

    #endregion
}