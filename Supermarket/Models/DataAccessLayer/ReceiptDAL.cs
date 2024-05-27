using System.Data.SqlClient;
using System.Data;

namespace Supermarket.Models.DataAccessLayer;

public class ReceiptDAL
{
    public void CreateReceipt(string cashierName, string shoppingListJsonList, decimal totalPrice)
    {
        SqlConnection connection = DALHelper.Connection;
        SqlCommand command = new("[AddReceipt]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        SqlParameter cashierNameParam = new("@cashierName", SqlDbType.VarChar)
        {
            Value = cashierName
        };
        SqlParameter shoppingListParam = new("@productList", SqlDbType.VarChar, -1)
        {
            Value = shoppingListJsonList
        };
        SqlParameter totalPriceParam = new("@totalPrice", SqlDbType.Decimal)
        {
            Value = totalPrice,
            Precision = 18,
            Scale = 2
        };
        command.Parameters.Add(cashierNameParam);
        command.Parameters.Add(shoppingListParam);
        command.Parameters.Add(totalPriceParam);
        connection.Open();
        command.ExecuteNonQuery();

    }
}