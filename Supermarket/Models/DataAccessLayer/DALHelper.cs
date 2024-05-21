using System.Configuration;
using System.Data.SqlClient;
namespace Supermarket.Models.DataAccessLayer;

public static class DALHelper
{
    private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;

    public static SqlConnection Connection
    {
        get
        {
            return new SqlConnection(ConnectionString);
        }
    }
}