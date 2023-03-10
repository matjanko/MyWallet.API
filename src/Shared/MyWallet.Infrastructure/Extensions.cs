using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWallet.Infrastructure.ApiDoc;

[assembly: InternalsVisibleTo("MyWallet.Api")]
namespace MyWallet.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddApiDoc(configuration);
        
        services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
        });
        
        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app, 
        IWebHostEnvironment environment, IConfiguration configuration)
    {
        if (environment.IsDevelopment())
        {
            app.UseApiDoc(configuration);
        }

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        
        return app;
    }
}