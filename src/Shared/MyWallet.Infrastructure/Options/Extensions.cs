using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWallet.Abstractions.Options;

namespace MyWallet.Infrastructure.Options;

public static class Extensions
{
    public static T GetOptions<T>(this IServiceCollection services)
        where T : IOptions, new()
    {
        using var provider = services.BuildServiceProvider();
        var configuration = provider.GetRequiredService<IConfiguration>();
        return GetOptions<T>(configuration);   
    }

    private static T GetOptions<T>(IConfiguration configuration) where T : IOptions, new()
    {
        var options = new T();
        configuration.GetSection(options.SectionName).Bind(options);
        return options;
    }
}