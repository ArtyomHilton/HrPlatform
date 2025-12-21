using System.Reflection;
using FluentValidation;
using HrPlatform.Application.Extensions;
using HrPlatform.Infrastructure.Extensions;
using HrPlatform.Infrastructure.Persistence.Postgre.Extensions;

namespace HrPlatform.Web.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddRepositories();
        serviceCollection.AddServices(configuration);
        serviceCollection.AddContext(configuration);
        serviceCollection.AddValidators();
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

    private static IServiceCollection AddValidators(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return serviceCollection;
    }
}