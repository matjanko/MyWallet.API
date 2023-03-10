using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWallet.Infrastructure.ApiDoc;

namespace MyWallet.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddApiDoc(configuration);
        
        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseApiDoc(configuration);
        
        return app;
    }
}