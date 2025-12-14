using Microsoft.Extensions.Configuration;

namespace HrPlatform.Infrastructure.FileStorage;

public class MinioFileStorageOptions
{
    [ConfigurationKeyName("MINIO_ENDPOINT")]
    public string Endpoint { get; set; } = string.Empty;

    [ConfigurationKeyName("MINIO_ACCESS_KEY")]
    public string AccessKey { get; set; } = string.Empty;

    [ConfigurationKeyName("MINIO_SECRET_KEY")]
    public string SecretKey { get; set; } = string.Empty;
}
