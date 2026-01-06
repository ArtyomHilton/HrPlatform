using HrPlatform.Application.Abstractions;
using HrPlatform.Infrastructure.Context;
using HrPlatform.Infrastructure.Options;
using HrPlatform.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HrPlatform.Infrastructure.Extensions;

public static class DependencyInjections
{
    extension (IServiceCollection serviceCollection)
    {
        public IServiceCollection AddInfrastructureDependencyInjection(IConfiguration configuration) =>
            serviceCollection
                .AddOptions(configuration)
                .AddServices()
                .AddDatabase();

        private IServiceCollection AddServices() =>
            serviceCollection
                .AddSingleton<IPasswordHasher, PasswordHasher>();

        private IServiceCollection AddDatabase() =>
            serviceCollection.AddDbContext<HrPlatformDbContext>((sp, options) =>
            {
                var databaseOptions = sp.GetRequiredService<DatabaseOptions>();

                options.UseNpgsql(databaseOptions.ConnectionString, opt =>
                {
                    opt.EnableRetryOnFailure(databaseOptions.RetryOnFailure);
                });
            });

        private IServiceCollection AddOptions(IConfiguration configuration)
        {
            serviceCollection.Configure<DatabaseOptions>(configuration.GetSection(nameof(DatabaseOptions)));

            serviceCollection.AddSingleton<DatabaseOptions>(sp => sp.GetRequiredService<IOptions<DatabaseOptions>>().Value);

            return serviceCollection;
        }
    }
}
