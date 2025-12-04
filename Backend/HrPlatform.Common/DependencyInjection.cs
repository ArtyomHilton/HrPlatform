using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HrPlatform.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddOptions(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        return serviceCollection;
    }
}
