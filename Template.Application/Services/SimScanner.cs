using Template.Domain.Scanner;

namespace Template.Application.Services;

public class SimBarcodeScanner: IBarcodeScanner
{
    private const string DeviceId = "SimScanner";

    public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;

    public void RaiseDummyEvent(string message)
    {
        var arg = new BarcodeScannedEventArgs(message, DeviceId);
        BarcodeScanned?.Invoke(this, arg);
        Console.WriteLine($"dummy event raised: {arg}");
    }
    
}

public interface IBarcodeScanner
{
    event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;
    void RaiseDummyEvent(string message);

}