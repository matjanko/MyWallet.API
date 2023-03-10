using MyWallet.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();
app.UseInfrastructure(builder.Configuration);

app.MapGet("/", () => "Hello World!");

app.Run();