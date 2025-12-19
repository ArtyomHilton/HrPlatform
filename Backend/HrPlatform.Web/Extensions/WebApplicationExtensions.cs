using HrPlatform.Persistence.Postgre.Context;
using Microsoft.EntityFrameworkCore;

namespace HrPlatform.Web.Extensions;

public static class WebApplicationExtensions
{
    public static async Task ApplyMigrationsAsync(this WebApplication webApplication)
    {
        var scope = webApplication.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<HrPlatformDbContext>();

        await context.Database.MigrateAsync();
    }
}