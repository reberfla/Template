using Microsoft.AspNetCore.Mvc;

namespace GreenKasse.WebHost.Controllers;

[Route("/api/[controller]")]
public class MyController: ControllerBase
{
    [HttpGet("my-get")]
    public string MyGet()
    {
        return $"Hello from {nameof(MyController)}!";
    }
}