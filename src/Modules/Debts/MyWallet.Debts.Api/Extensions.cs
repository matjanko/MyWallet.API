using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Mywallet.Api")]
namespace MyWallet.Debts.Api;

internal static class Extensions
{
    public static IServiceCollection AddDebtsModule(this IServiceCollection services)
    {
        return services;
    }
}