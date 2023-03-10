using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("MyWallet.Api")]
namespace MyWallet.Expenses.Api;

internal static class Extensions
{
    public static IServiceCollection AddExpensesModule(this IServiceCollection services)
    {
        
        return services;
    } 
}