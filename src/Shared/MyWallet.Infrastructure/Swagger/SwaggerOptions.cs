namespace MyWallet.Shared.Infrastructure.Swagger;

public class SwaggerOptions
{
    public const string Swagger = "Swagger";

    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Prefix { get; set; } = string.Empty;
}