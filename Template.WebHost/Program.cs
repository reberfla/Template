using Template.WebHost.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(configure =>
{
    configure.DocumentName = "green-kasse-api-definition";
    configure.Title = "Green Kasse Docs";
});

builder.Services.AddSingleton<IInfoService, MeinInfoService>();

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi();
app.UseRouting();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();