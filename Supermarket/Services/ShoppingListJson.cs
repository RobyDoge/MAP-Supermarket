using System.Text.Json;

namespace Supermarket.Services;

public class ShoppingListJson
{
    public Dictionary<string, Tuple<int, decimal>> ShoppingList { get; set; } = [];
    public string JsonList { get;set; } = "";

    public decimal TotalPrice { get; set; }
    public ShoppingListJson(Dictionary<string, Tuple<int, decimal>> shoppingList)
    {
        ShoppingList = shoppingList;
        TotalPrice = 0;
        CreateJson();
    }

    public ShoppingListJson(string jsonList)
    {
        JsonList=jsonList;
        TotalPrice = 0;
        CreateShoppingList();
    }

    private void CreateJson()
    {
        UpdateShoppingList();
        JsonList = JsonSerializer.Serialize(ShoppingList);
    }

    private void UpdateShoppingList()
    {
        Dictionary<string, Tuple<int, decimal>> newList = new();
        foreach (var product in ShoppingList)
        {
            newList.Add(product.Key, new Tuple<int, decimal>(product.Value.Item1, product.Value.Item2* product.Value.Item1));
            TotalPrice += product.Value.Item2 * product.Value.Item1;
        }
        ShoppingList = newList;
    }

    private void CreateShoppingList()
    {
        if(JsonList.Length > 0)
            ShoppingList = JsonSerializer.Deserialize<Dictionary<string, Tuple<int, decimal>>>(JsonList);
    }
}