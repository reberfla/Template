using System.Text.Json;

namespace Template.Domain.ShoppingCart;

public class ShoppingCart
{
    private readonly List<Tuple<int, string>> _positions = [];

    public void AddItem(string description)
    {
        _positions.Add(new(_positions.Count, description));
    }

    public string GetItems()
    {
        return JsonSerializer.Serialize(_positions);
    }

}