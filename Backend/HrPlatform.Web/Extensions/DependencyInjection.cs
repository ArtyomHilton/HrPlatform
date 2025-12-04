using HrPlatform.Infrastructure.Persistence.Postgre.Extensions;
using HrPlatform.MessageBus.RabbitMQ.Extensions;

namespace HrPlatform.Web.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddServices(configuration);
        serviceCollection.AddContext(configuration);

        return serviceCollection;
    }

    private static IServiceCollection AddServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMessageBus(configuration);

        return serviceCollection;
    }
}
