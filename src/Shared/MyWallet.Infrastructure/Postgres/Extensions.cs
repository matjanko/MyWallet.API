using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyWallet.Infrastructure.Options;

namespace MyWallet.Infrastructure.Postgres;

public static class Extensions
{
    public static IServiceCollection AddPostgres<TContext>(this IServiceCollection services)
        where TContext : DbContext
    {
        var postgresOptions = services.GetOptions<PostgresOptions>();
        services.AddDbContext<TContext>(x =>
        {
            x.UseNpgsql(postgresOptions.ConnectionString);
        });
        return services;
    }
}