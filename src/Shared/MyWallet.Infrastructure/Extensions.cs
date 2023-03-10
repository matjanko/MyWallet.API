using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app, 
        IWebHostEnvironment environment, IConfiguration configuration)
    {
        if (environment.IsDevelopment())
        {
            app.UseApiDoc(configuration);
        }

        return app;
    }
}