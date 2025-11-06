using Template.Domain.Scanner;

namespace Template.Application.Services;

public class ScannerHandlerService : IScannerHandlerService
{
    public void OnBarcodeScanned(BarcodeScannedEventArgs args)
    {
        Console.WriteLine($"[ScannerHandlerService] Scanned {args.Barcode} from {args.DeviceId} at {args.OccurredAtUtc:O}");
    }
}

public interface IScannerHandlerService
{
    public void OnBarcodeScanned(BarcodeScannedEventArgs args);
}