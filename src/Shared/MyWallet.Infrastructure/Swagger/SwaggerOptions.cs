
using MyWallet.Abstractions.Options;

namespace MyWallet.Infrastructure.Swagger;

public class SwaggerOptions : IOptions
{
    public string SectionName => "Swagger";

    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Prefix { get; set; } = string.Empty;
    
}