using HrPlatform.Application.Abstractions;
using HrPlatform.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HrPlatform.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencyInjection(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddServices();

        return serviceCollection;
    }

    static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IPasswordHashedService, PasswordHashedService>();

        return serviceCollection;
    }
}
