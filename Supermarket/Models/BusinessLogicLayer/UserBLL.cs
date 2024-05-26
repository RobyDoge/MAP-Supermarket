using System.Collections.ObjectModel;
using Supermarket.Models.DataAccessLayer;

namespace Supermarket.Models.BusinessLogicLayer;

public class UserBLL
{
    private UserDAL UserDal { get; set; } = new();
    public ObservableCollection<string> Type { get; set; } = new();
    public void CheckLoginInfo(ObservableCollection<string> loginInfo)
    {
        Type = UserDal.CheckLoginInfo(loginInfo[0], loginInfo[1]);
    }

    public void CreateUser(ObservableCollection<string> loginInfo)
    {
        var type = loginInfo[2] == "true" ? true : false;
        UserDal.CreateUser(loginInfo[0], loginInfo[1], type);
    }
}