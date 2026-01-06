using Microsoft.Extensions.Configuration;

namespace HrPlatform.Infrastructure.Options;

public class DatabaseOptions
{
    [ConfigurationKeyName("CONNECTION_STRING")]
    public required string ConnectionString { get; set; }

    [ConfigurationKeyName("RETRY_ON_FAILURE")]
    public int RetryOnFailure { get; set; } = default;
}
