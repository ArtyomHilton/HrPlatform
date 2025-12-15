using HrPlatform.Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Minio;

namespace HrPlatform.Infrastructure.FileStorage.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddFileStorage(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<MinioFileStorageOptions>(configuration.GetSection(nameof(MinioFileStorageOptions)));
        serviceCollection.AddSingleton(sp => sp.GetRequiredService<IOptions<MinioFileStorageOptions>>().Value);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var settings = serviceProvider.GetRequiredService<MinioFileStorageOptions>();

        serviceCollection.AddMinio(configure =>
        {
            configure.WithEndpoint(settings.Endpoint);
            configure.WithCredentials(settings.AccessKey, settings.SecretKey);
        });

        serviceCollection.AddSingleton<IFileStorage, MinioFileStorage>();

        return serviceCollection;
    }
}
