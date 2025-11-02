using Microsoft.AspNetCore.Mvc;

using Template.Application.Services;


namespace Template.WebHost.Controllers;

[Route("/api/[controller]")]
public class ShoppingController([FromServices] PurchaseService purchaseService)
{
    [HttpGet("cart")]
    public string GetShoppingCart()
    {
        return purchaseService.GetItems();
    }

    [HttpGet("add")]
    public void AddItem()
    {
        string product = $"Product # {new Random().NextInt64(10)}";
        purchaseService.AddItem(product);
    }

    [HttpGet("new")]
    public void NewCart()
    {
        purchaseService.ResetCart();
    }
    
}