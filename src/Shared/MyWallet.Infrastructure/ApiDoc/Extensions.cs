using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyWallet.Infrastructure.Options;
using MyWallet.Infrastructure.Swagger;

namespace MyWallet.Infrastructure.ApiDoc;

public static class Extensions
{
    public static IServiceCollection AddApiDoc(this IServiceCollection services, IConfiguration configuration)
    {
        var swaggerOptions = services.GetOptions<SwaggerOptions>(configuration);
        
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(swaggerOptions.Name, new OpenApiInfo
            {
                Title = swaggerOptions.Title, 
                Version = swaggerOptions.Version
            });
        });
        
        return services;
    }
    
    public static IApplicationBuilder UseApiDoc(this IApplicationBuilder app, IConfiguration configuration)
    {
        var swaggerOptions = app.GetOptions<SwaggerOptions>(configuration);
        
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/my-wallet/swagger.json", swaggerOptions.Title);
            options.RoutePrefix = swaggerOptions.Prefix;
        });
        
        return app;
    }
}