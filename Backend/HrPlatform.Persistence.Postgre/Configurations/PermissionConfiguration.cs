using HrPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;

namespace HrPlatform.Persistence.Postgre.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable(nameof(Permission));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .IsRequired();
        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.Property<uint>("Version")
            .IsRowVersion();

        builder.Property(u => u.CreatedAt)
            .HasDefaultValueSql(PersistenceConstants.NowDateTime);

        builder.Property(u => u.UpdatedAt)
            .HasDefaultValueSql(PersistenceConstants.NowDateTime);
    }
}
