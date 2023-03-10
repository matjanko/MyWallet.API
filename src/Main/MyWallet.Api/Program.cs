using MyWallet.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddInfrastructure(configuration);


var app = builder.Build();
app.UseInfrastructure(configuration);

app.MapGet("/", () => "Hello World!");

app.Run();