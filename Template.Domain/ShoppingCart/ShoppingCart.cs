using System.Text.Json;

namespace Template.Domain.ShoppingCart;

public class ShoppingCart
{
    private List<Tuple<int, string>> _positions = new List<Tuple<int, string>>();
    
    public void AddItem(string description)
    {
        _positions.Add(new (_positions.Count, description));
    }

    public string GetItems()
    {
        return JsonSerializer.Serialize(_positions);
    }

}