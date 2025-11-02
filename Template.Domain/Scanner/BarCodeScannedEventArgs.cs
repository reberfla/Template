namespace Template.Domain.Scanner;

public class BarcodeScannedEventArgs : EventArgs
{
    public string Barcode { get; }
    public DateTime OccurredAtUtc { get; }
    public string DeviceId { get; }

    public BarcodeScannedEventArgs(string barcode, string deviceId = null)
    {
        Barcode = barcode;
        DeviceId = deviceId ?? "unknown";
        OccurredAtUtc = DateTime.UtcNow;
    }
}
