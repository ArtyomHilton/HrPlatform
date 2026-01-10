using HrPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrPlatform.Infrastructure.Database.Configurations;

class RolePersistenceConfiguration : IEntityTypeConfiguration<RolePersistence>
{
    public void Configure(EntityTypeBuilder<RolePersistence> builder)
    {
        builder.ToTable(nameof(RolePersistence));

        builder.HasKey(rp => new { rp.RoleId, rp.PersistenceId });

        builder.HasOne(rp => rp.Role)
            .WithMany(r => r.RolePersistences)
            .HasForeignKey(rp => rp.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rp => rp.Persistence)
            .WithMany(p => p.RolePersistences)
            .HasForeignKey(rp => rp.PersistenceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
