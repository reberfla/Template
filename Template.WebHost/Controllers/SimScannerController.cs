using Microsoft.AspNetCore.Mvc;

using Template.Application.Services;

namespace Template.WebHost.Controllers;

[Route("/api/[controller]")]
public class SimScannerController([FromServices] IBarcodeScanner barcodeScanner)
{
    [HttpGet("simulate")]
    public string Simulate()
    {
        barcodeScanner.RaiseDummyEvent("scanner event triggered from controller");
        return "scanned event raised";
    }

}