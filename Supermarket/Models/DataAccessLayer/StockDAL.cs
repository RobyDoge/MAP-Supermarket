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

    public void UpdateStock(string productName, int quantity)
    {
        int stockId = DecreaseStock(productName, quantity);
        DeleteEmptyStock(stockId);
        DeactivateProductIfNoStockAvailable(productName);
    }

    private void DeactivateProductIfNoStockAvailable(string productName)
    {
        SqlConnection connection = DALHelper.Connection;
        SqlCommand command = new("[DeactivateProductIfNoActiveStock]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        SqlParameter productNameParam = new("@ProductName", SqlDbType.VarChar)
        {
            Value = productName
        };
        command.Parameters.Add(productNameParam);
        connection.Open();
        command.ExecuteNonQuery();
        
    }

    private void DeleteEmptyStock(int stockId)
    {
        SqlConnection connection = DALHelper.Connection;
        SqlCommand command = new("[DeactivateStockIfEmpty]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        SqlParameter stockIdParam = new("@StockId", SqlDbType.Int)
        {
            Value = stockId
        };
        command.Parameters.Add(stockIdParam);
        connection.Open();
        command.ExecuteNonQuery();
    }

    private int DecreaseStock(string productName, int quantity)
    {
        SqlConnection connection = DALHelper.Connection;
        SqlCommand command = new("[DecreaseStockByProductName]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        SqlParameter productNameParam = new("@ProductName", SqlDbType.VarChar)
        {
            Value = productName
        };
        SqlParameter quantityParam = new("@Quantity", SqlDbType.Int)
        {
            Value = quantity
        };
        SqlParameter stockId = new("@StockId", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };
        command.Parameters.Add(productNameParam);
        command.Parameters.Add(quantityParam);
        command.Parameters.Add(stockId);
        connection.Open();
        command.ExecuteNonQuery();
        return (int)stockId.Value;
    }
}