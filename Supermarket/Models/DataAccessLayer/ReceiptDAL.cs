using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using Supermarket.Models.EntityLayer;

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

    public ObservableCollection<Receipt> GetReceipts()
    {
        SqlConnection connection = DALHelper.Connection;
        SqlCommand command = new("[GetReceipts]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        ObservableCollection<Receipt> receipts = new();
        while (reader.Read())
        {
            receipts.Add(new()
            {
                Id = (int)reader["id"],
                CashierId = (int)reader["cashier_id"],
                Total = (decimal)reader["total_sum"],
                ProductsJson = reader["product_list"].ToString()
            });
        }
        reader.Close();
        return receipts;
    }

    public string GetCashierName(int receiptId)
    {
        SqlConnection connection = DALHelper.Connection;
        SqlCommand command = new("[GetCashierName]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        SqlParameter receiptIdParam = new("@ReceiptID", SqlDbType.Int)
        {
            Value = receiptId
        };
        command.Parameters.Add(receiptIdParam);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        string cashierName = "";
        while (reader.Read())
        {
            cashierName = reader["CashierName"].ToString();
        }
        reader.Close();
        return cashierName;
    }
}