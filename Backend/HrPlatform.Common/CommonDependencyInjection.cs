using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;

namespace HrPlatform.Common;

public static class CommonDependencyInjection
{
    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration
                .Enrich.WithProperty("Application", "HrPlatform")
                .MinimumLevel.Override("Microsoft.AspNetCore.Watch.BrowserRefresh", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Watch", LogEventLevel.Warning) 
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning) 
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                .WriteTo.File(path: "logs/log-.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information);
        });

    }
}
