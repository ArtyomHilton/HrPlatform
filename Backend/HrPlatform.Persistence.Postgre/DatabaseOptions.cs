using Microsoft.Extensions.Configuration;

namespace HrPlatform.Persistence.Postgre;

public class DatabaseOptions
{
    [ConfigurationKeyName("DATABASE_CONNECTION_STRING")]
    public string ConnectionString { get; set; } = string.Empty;

    [ConfigurationKeyName("RETRY_ON_FAILURE")]
    public int RetryOnFailure { get; set; }
}
