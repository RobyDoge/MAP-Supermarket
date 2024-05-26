using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.JavaScript;

namespace Supermarket.Models.DataAccessLayer;

public class ProductDAL
{

    public ObservableCollection<string> SearchProductsByExpirationDate(string searchText)
    {
        throw new NotImplementedException();
    }

    public ObservableCollection<string> SearchProductsByName(string searchText)
    {
        using SqlConnection connection = DALHelper.Connection;
        SqlCommand command = new("[GetProductsByName]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        SqlParameter searchTextParam = new("@searchName", SqlDbType.VarChar)
        {
            Value = searchText
        };
        command.Parameters.Add(searchTextParam);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        ObservableCollection<string> foundProducts = new();
        while (reader.Read())
        {
            foundProducts.Add(reader["Name"].ToString());
        }
        return foundProducts;
    }

    public ObservableCollection<string> SearchProductsByBarcode(string searchInfoItem2)
    {
        throw new NotImplementedException();
    }

    public ObservableCollection<string> SearchProductsByProducer(string searchInfoItem2)
    {
        throw new NotImplementedException();
    }

    public ObservableCollection<string> SearchProductsByCategory(string searchInfoItem2)
    {
        throw new NotImplementedException();
    }

    public ObservableCollection<string> GetProductInfo(string productName)
    {
        using SqlConnection connection = DALHelper.Connection;
        SqlCommand command = new("[GetProductDetails]", connection)
        {
            CommandType = CommandType.StoredProcedure
        };
        SqlParameter searchTextParam = new("@productName", SqlDbType.VarChar)
        {
            Value = productName
        };
        command.Parameters.Add(searchTextParam);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        ObservableCollection<string> productInfo = new();
        while (reader.Read())
        {
            productInfo.Add(reader["ProductName"] as string);
            productInfo.Add(reader["Barcode"] as string);
            productInfo.Add(reader["Category"] as string);
            productInfo.Add(reader["ProducerName"] as string);
            var expirationDate = reader.GetDateTime("OldestExpirationDate").ToString();
            if (!expirationDate.Contains("99")) productInfo.Add(reader["OldestExpirationDate"] as string);
            else productInfo.Add("No expiration date");
            var purchasePrice = (decimal)reader["PurchasePrice"];
            var profitMargin = (decimal)reader["ProfitMargin"];
            var sellingPrice = purchasePrice + (purchasePrice * profitMargin);
            productInfo.Add(sellingPrice.ToString());
        }
        return productInfo;
        
    }
}