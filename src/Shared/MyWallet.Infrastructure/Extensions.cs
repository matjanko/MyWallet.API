using System.Runtime.CompilerServices;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

[assembly: InternalsVisibleTo("MyWallet.Api")]
namespace MyWallet.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddFastEndpoints();
        services.AddSwaggerDoc();
        
        
        services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
        });
        
        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app, 
        IWebHostEnvironment environment, IConfiguration configuration)
    {
        app.UseRouting();
        app.UseAuthorization();
        app.UseFastEndpoints();
        app.UseCors();
        
        if (environment.IsDevelopment())
        {
            app.UseSwaggerGen();
        }
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        
        return app;
    }
}