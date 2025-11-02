using Template.Application.Services;
using Template.Domain.Scanner;

using YamlDotNet.Core;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(configure =>
{
    configure.DocumentName = "green-kasse-api-definition";
    configure.Title = "Green Kasse Docs";
});

builder.Services.AddSingleton<IInfoService, MeinInfoService>();
builder.Services.AddSingleton<IScannerHandlerService, ScannerHandlerService>();
builder.Services.AddSingleton<IBarcodeScanner, SimBarcodeScanner>();

var app = builder.Build();

var scannerHandler = app.Services.GetRequiredService<IScannerHandlerService>();
var scanner = app.Services.GetRequiredService<IBarcodeScanner>();
scanner.BarcodeScanned += (s, args) => scannerHandler.OnBarcodeScanned(args);

app.UseOpenApi();
app.UseSwaggerUi();
app.UseRouting();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();