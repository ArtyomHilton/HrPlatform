using System.Reflection;
using HrPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HrPlatform.Infrastructure.Context;

public class HrPlatformDbContext : DbContext
{
    public HrPlatformDbContext(DbContextOptions<HrPlatformDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    DbSet<User> Users => Set<User>();
    DbSet<Position> Positions => Set<Position>();
}
