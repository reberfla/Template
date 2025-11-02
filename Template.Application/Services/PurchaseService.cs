using Template.Domain.Scanner;
using Template.Domain.ShoppingCart;

namespace Template.Application.Services;

public class PurchaseService: IScannerHandlerService
{
    private ShoppingCart _shoppingCart = new ShoppingCart();
    
    public void OnBarcodeScanned(BarcodeScannedEventArgs args)
    {
        _shoppingCart.AddItem(args.Barcode);
    }

    public void AddItem(string description)
    {
        _shoppingCart.AddItem(description);
    }

    public string GetItems()
    {
        return _shoppingCart.GetItems();
    }

    public void ResetCart()
    {
        _shoppingCart = new ShoppingCart();
    }
}
