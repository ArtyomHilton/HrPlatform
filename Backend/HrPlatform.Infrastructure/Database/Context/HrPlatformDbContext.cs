using System.Reflection;
using HrPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HrPlatform.Infrastructure.Database.Context;

public class HrPlatformDbContext : DbContext
{
    public HrPlatformDbContext(DbContextOptions<HrPlatformDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DatabaseConstants.Schema.SchemaName);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    DbSet<User> Users => Set<User>();
    DbSet<Position> Positions => Set<Position>();
    DbSet<Role> Roles => Set<Role>();
    DbSet<Persistence> Persistences => Set<Persistence>();
    DbSet<UserRole> UserRoles => Set<UserRole>();
    DbSet<RolePersistence> RolePersistences => Set<RolePersistence>();
}
