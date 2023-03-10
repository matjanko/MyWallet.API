using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MyWallet.Shared.Infrastructure.Swagger;

namespace MyWallet.Shared.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var swaggerOptions = new SwaggerOptions();
        configuration.GetSection(SwaggerOptions.Swagger).Bind(swaggerOptions);
        
        services.AddControllers();
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

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app, IConfiguration configuration)
    {
        var swaggerOptions = new SwaggerOptions();
        configuration.GetSection(SwaggerOptions.Swagger).Bind(swaggerOptions);
        
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/my-wallet/swagger.json", swaggerOptions.Title);
            options.RoutePrefix = swaggerOptions.Prefix;
        });
        
        return app;
    }
}