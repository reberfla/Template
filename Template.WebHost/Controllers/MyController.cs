using Microsoft.AspNetCore.Mvc;

using Template.WebHost.Services;

namespace Template.WebHost.Controllers;

[Route("/api/[controller]")]
public class MyController(IInfoService infoService) : ControllerBase
{
    private readonly IInfoService _infoService = infoService;

    [HttpGet("my-get")]
    public string MyGet()
    {
        var info = _infoService.GibMirInfo().ToString("F");
        return $"Hello from {nameof(MyController)}, current date: {info}!";
    }
}