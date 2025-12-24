using HrPlatform.Application.UseCases.AuthUseCases.Login;
using HrPlatform.Application.UseCases.AuthUseCases.Registration;
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
        serviceCollection.AddScoped<ILoginUseCase, LoginUseCase>();

        return serviceCollection;
    }
}
