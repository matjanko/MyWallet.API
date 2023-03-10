using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWallet.Abstractions.Options;

namespace MyWallet.Infrastructure.Options;

public static class Extensions
{
    public static T GetOptions<T>(this IServiceCollection services, IConfiguration configuration)
        where T : IOptions, new() => GetOptions<T>(configuration);

    public static T GetOptions<T>(this IApplicationBuilder app, IConfiguration configuration)
        where T : IOptions, new() => GetOptions<T>(configuration);

    private static T GetOptions<T>(IConfiguration configuration) where T : IOptions, new()
    {
        var options = new T();
        configuration.GetSection(options.SectionName).Bind(options);
        return options;
    }
}