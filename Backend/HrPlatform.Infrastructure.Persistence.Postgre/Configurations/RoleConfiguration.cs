using HrPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrPlatform.Persistence.Postgre.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(nameof(Role));

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .IsRequired();
        builder.HasIndex(r => r.Name)
            .IsUnique();

        builder.Property(u => u.Version)
            .IsRowVersion();

        builder.Property(u => u.CreatedAt)
            .HasDefaultValueSql(PersistenceConstants.NowDateTime);

        builder.Property(u => u.UpdatedAt)
            .HasDefaultValueSql(PersistenceConstants.NowDateTime);
    }
}
