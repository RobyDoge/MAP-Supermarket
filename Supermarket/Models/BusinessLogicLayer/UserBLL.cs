using System.Collections.ObjectModel;
using Supermarket.Models.DataAccessLayer;

namespace Supermarket.Models.BusinessLogicLayer;

public class UserBLL
{
    private UserDAL UserDal { get; set; } = new();

    public ObservableCollection<string> CheckLoginInfo(string username, string password)
    {
        return UserDal.CheckLoginInfo(username, password);
    }

    public void CreateUser(string username, string password, bool type)
    {
        UserDal.CreateUser(username, password,type);
    }
}