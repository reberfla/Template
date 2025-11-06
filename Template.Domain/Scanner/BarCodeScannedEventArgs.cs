namespace Template.Domain.Scanner;

public class BarcodeScannedEventArgs(string barcode, string deviceId = null) : EventArgs
{
    public string Barcode { get; } = barcode;
    public DateTime OccurredAtUtc { get; } = DateTime.UtcNow;
    public string DeviceId { get; } = deviceId ?? "unknown";
}