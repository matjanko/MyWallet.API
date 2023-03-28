using MyWallet.Abstractions.Options;

namespace MyWallet.Infrastructure.Postgres;

public class PostgresOptions : IOptions
{
    public string SectionName => "Postgres";

    public string ConnectionString { get; set; } = string.Empty;
}