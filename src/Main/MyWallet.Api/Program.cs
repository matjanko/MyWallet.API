using MyWallet.Debts.Api;
using MyWallet.Expenses.Api;
using MyWallet.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddInfrastructure(configuration);
builder.Services.AddExpensesModule();
builder.Services.AddDebtsModule();

var app = builder.Build();
app.UseInfrastructure(app.Environment, configuration);
app.MapGet("/", () => "Hello World!");

app.Run();