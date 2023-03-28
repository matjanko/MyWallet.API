using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using MyWallet.Debts.DAL;
using MyWallet.Infrastructure.Postgres;

[assembly: InternalsVisibleTo("MyWallet.Api")]
namespace MyWallet.Debts;

internal static class Extensions
{
    public static IServiceCollection AddDebtsModule(this IServiceCollection services)
    {
        services.AddPostgres<DebtsDbContext>();
        services.AddScoped<DebtsDbContext>();
        return services;
    }
}