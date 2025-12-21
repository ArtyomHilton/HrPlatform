using HrPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HrPlatform.Persistence.Postgre.Context;

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
        modelBuilder.HasDefaultSchema(nameof(HrPlatform));
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<Candidate> Candidates => Set<Candidate>();
}
