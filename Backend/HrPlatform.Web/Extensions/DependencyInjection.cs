using HrPlatform.Application.Extensions;
using HrPlatform.Infrastructure.Extensions;
using HrPlatform.Infrastructure.FileStorage.Extensions;
using HrPlatform.Infrastructure.Persistence.Postgre.Extensions;

namespace HrPlatform.Web.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddServices(configuration);
        serviceCollection.AddContext(configuration);
        serviceCollection.AddApplicationDependencyInjection();

        return serviceCollection;
    }

    private static IServiceCollection AddServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        //serviceCollection.AddMessageBus(configuration);
        serviceCollection.AddInfrastructureDependencyInjection();
        //serviceCollection.AddFileStorage(configuration);

        return serviceCollection;
    }
}
