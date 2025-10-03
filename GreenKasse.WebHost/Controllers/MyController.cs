using GreenKasse.WebHost.Services;

using Microsoft.AspNetCore.Mvc;

namespace GreenKasse.WebHost.Controllers;

[Route("/api/[controller]")]
public class MyController: ControllerBase
{
    private readonly IInfoService _infoService;
    public MyController(IInfoService infoService)
    {
        _infoService = infoService;
    }
    
    [HttpGet("my-get")]
    public string MyGet()
    {
        var info = _infoService.GibMirInfo().ToString("F");
        return $"Hello from {nameof(MyController)}, current date: {info}!";
    }
}