using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HrPlatform.Infrastructure.Persistence.Postgre.Context;

/// <summary>
/// Контекст БД приложения.
/// </summary>
public class HrPlatformDbContext : DbContext
{
    public HrPlatformDbContext(DbContextOptions<HrPlatformDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
