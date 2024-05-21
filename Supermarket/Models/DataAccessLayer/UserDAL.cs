using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace Supermarket.Models.DataAccessLayer;

public class UserDAL
{
    public ObservableCollection<string> CheckLoginInfo(string username,string password)
    {
        using SqlConnection connection = DALHelper.Connection;
        SqlCommand command = new("CheckLoginInfo", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        SqlParameter usernameParam = new("@Username", SqlDbType.VarChar)
        {
            Value = username
        };
        SqlParameter passwordParam = new("@Password", SqlDbType.VarChar)
        {
            Value = password
        };
        SqlParameter typeOrError = new("@TypeOrError", SqlDbType.VarChar)
        {
            Direction = ParameterDirection.Output
        };
        command.Parameters.Add(usernameParam);
        command.Parameters.Add(passwordParam);
        connection.Open();
        command.ExecuteNonQuery();
        return [typeOrError.Value as string];
    }

    public void CreateUser(string username, string password, bool isAdmin)
    {
        using SqlConnection connection = DALHelper.Connection;
        SqlCommand command = new("CreateUser", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        SqlParameter usernameParam = new("@Username", SqlDbType.VarChar)
        {
            Value = username
        };
        SqlParameter passwordParam = new("@Password", SqlDbType.VarChar)
        {
            Value = password
        };
        SqlParameter isAdminParam = new("@IsAdmin", SqlDbType.Bit)
        {
            Value = isAdmin
        };
        command.Parameters.Add(usernameParam);
        command.Parameters.Add(passwordParam);
        command.Parameters.Add(isAdminParam);
        connection.Open();
        command.ExecuteNonQuery();
    }
}