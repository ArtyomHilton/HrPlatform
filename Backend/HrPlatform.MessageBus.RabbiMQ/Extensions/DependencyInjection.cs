using System.Reflection;
using HrPlatform.Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Rebus.Config;
using Rebus.Retry.Simple;

namespace HrPlatform.MessageBus.RabbitMQ.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddMessageBus(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<MessageBusOptions>(configuration.GetSection(nameof(MessageBusOptions)));
        serviceCollection.AddSingleton<MessageBusOptions>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MessageBusOptions>>().Value);

        serviceCollection.AddRebus((configure, serviceProvider) =>
        {
            var messageBusOptions = serviceProvider.GetRequiredService<MessageBusOptions>();

            configure.Transport(c => c.UseRabbitMq(messageBusOptions.ConnectionString, messageBusOptions.InputQueueName))
                .Options(o => o.RetryStrategy())
                .Start();

            return configure;
        }, true);

        serviceCollection.AutoRegisterHandlersFromAssembly(Assembly.GetExecutingAssembly());

        return serviceCollection;
    }
}