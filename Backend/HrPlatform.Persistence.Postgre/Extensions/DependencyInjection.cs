using HrPlatform.Persistence.Postgre;
using HrPlatform.Persistence.Postgre.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using HrPlatform.Persistence.Postgre.Abstractions;
using HrPlatform.Persistence.Postgre.Repositories;

namespace HrPlatform.Infrastructure.Persistence.Postgre.Extensions;

/// <summary>
/// Внедрение зависимостей.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Регистрирует контекст БД в DI.
    /// </summary>
    /// <param name="serviceCollection"><see cref="IServiceCollection"/></param>
    /// <param name="configuration"><see cref="IConfiguration"/></param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<DatabaseOptions>(configuration.GetSection(nameof(DatabaseOptions)));
        serviceCollection.AddSingleton<DatabaseOptions>(sp => sp.GetRequiredService<IOptions<DatabaseOptions>>().Value);

        serviceCollection.AddDbContext<HrPlatformDbContext>((serviceProvider, options) =>
        {
            var databaseOptions = serviceProvider.GetRequiredService<DatabaseOptions>();

            options.UseNpgsql(databaseOptions.ConnectionString, npgsqlOptions =>
            {
                npgsqlOptions.EnableRetryOnFailure(databaseOptions.RetryOnFailure);
            });
        });

        return serviceCollection;
    }

    /// <summary>
    /// Регистриуем репозитории
    /// </summary>
    /// <param name="serviceCollection"><see cref="IServiceCollection"/></param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection) =>
        serviceCollection
            .AddScoped<IRegisterUserRepository, RegisterUserRepository>()
            .AddScoped<ILoginUserRepository, LoginUserRepository>();
}