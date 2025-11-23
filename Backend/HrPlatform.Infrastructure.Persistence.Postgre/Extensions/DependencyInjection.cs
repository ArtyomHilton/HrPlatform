using HrPlatform.Infrastructure.Persistence.Postgre.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HrPlatform.Infrastructure.Persistence.Postgre.Extensions;

/// <summary>
/// Внедрение зависимостей.
/// </summary>
public static class DependencyInjection
{
    private const string ConnectionStringName = "POSTGRE_CONNECTION_STRING";
    private const int RetryOnFailure = 10;

    /// <summary>
    /// Регистрирует контекст БД в DI.
    /// </summary>
    /// <param name="serviceCollection"><see cref="IServiceCollection"/></param>
    /// <param name="configuration"><see cref="IConfiguration"/></param>
    /// <returns><see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<HrPlatformDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(ConnectionStringName), npgsqlOptions =>
            {
                npgsqlOptions.EnableRetryOnFailure(RetryOnFailure);
            });
        });

        return serviceCollection;
    }
}