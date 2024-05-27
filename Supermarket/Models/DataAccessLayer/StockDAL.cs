using System.Data.SqlClient;
using System.Data;

namespace Supermarket.Models.DataAccessLayer;

public class StockDAL
{
    public bool CheckStock(string productName, int quantity)
    {
        using SqlConnection connection = DALHelper.Connection;
        SqlCommand command = new("[CheckStockAvailability]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        SqlParameter productNameParam = new("@productName", SqlDbType.VarChar)
        {
            Value = productName
        };
        SqlParameter quantityParam = new("@requiredQuantity", SqlDbType.Int)
        {
            Value = quantity
        };
        SqlParameter isAvailable = new("@isAvailable", SqlDbType.Bit)
        {
            Direction = ParameterDirection.Output
        };
        command.Parameters.Add(productNameParam);
        command.Parameters.Add(quantityParam);
        command.Parameters.Add(isAvailable);
        connection.Open();
        command.ExecuteNonQuery();
        var result = isAvailable.Value;
        return (bool)isAvailable.Value;
    }
}