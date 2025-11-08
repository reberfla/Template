using Mumrich.SpaDevMiddleware.Extensions;

using Template.Application.Services;
using Template.Domain.Scanner;
using Template.WebHost;

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
builder.Services.AddSingleton<IBarcodeScanner, SimBarcodeScanner>();
builder.Services.AddSingleton<PurchaseService, PurchaseService>();
var appSettings = builder.Configuration.Get<AppSettings>();

builder.SetupSpaDevMiddleware(appSettings);

var app = builder.Build();

var scannerHandler = app.Services.GetRequiredService<PurchaseService>();
var scanner = app.Services.GetRequiredService<IBarcodeScanner>();
scanner.BarcodeScanned += (s, args) => scannerHandler.OnBarcodeScanned(args);

app.UseOpenApi();
app.UseSwaggerUi();
app.UseRouting();
app.MapControllers();

app.MapSinglePageApps(appSettings);
app.Run();