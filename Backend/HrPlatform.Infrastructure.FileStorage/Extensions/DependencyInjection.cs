using HrPlatform.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Minio;

namespace HrPlatform.Infrastructure.FileStorage.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddFileStorage(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMinio(configure =>
        {

        });

        serviceCollection.AddScoped<IFileStorage, MinioFileStorage>();

        return serviceCollection;
    }
}
