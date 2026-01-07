using HrPlatform.Infrastructure.Extensions;

namespace HrPlatform.Web.Extensions;

public static class DependencyInjection
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddDependencyInjection(IConfiguration configuration) =>
            serviceCollection
                .AddInfrastructureDependencyInjection(configuration);
    }
}
