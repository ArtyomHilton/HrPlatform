using HrPlatform.Application.UseCases.UserUseCases.RegistrationUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace HrPlatform.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddUseCases();

        return serviceCollection;
    }

    static IServiceCollection AddUseCases(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IRegistrationUseCase, RegistrationUseCase>();

        return serviceCollection;
    }
}
