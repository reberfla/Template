using Microsoft.AspNetCore.Mvc;

using Template.Application.Services;

namespace Template.WebHost.Controllers;

[Route("/api/[controller]")]
public class MyController([FromServices] IInfoService infoService) : ControllerBase
{
    [HttpGet("my-get")]
    public string MyGet()
    {
        var info = infoService.GibMirInfo().ToString("F");
        return $"Hello from {nameof(MyController)}, current date: {info}!";
    }
}