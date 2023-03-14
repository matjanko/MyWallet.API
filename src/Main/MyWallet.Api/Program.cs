using MyWallet.Debts;
using MyWallet.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddInfrastructure(configuration);
builder.Services.AddDebtsModule();

var app = builder.Build();
app.UseInfrastructure(app.Environment, configuration);
app.MapGet("/", () => "Hello World!");

app.Run();