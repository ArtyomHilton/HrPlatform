using HrPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrPlatform.Persistence.Postgre.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired();
        builder.HasIndex(u => u.Username)
            .IsUnique();

        builder.Property(u => u.Email)
            .IsRequired();
        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.Property(u => u.Version)
            .IsRowVersion();

        builder.Property(u => u.CreatedAt)
            .HasDefaultValueSql(PersistenceConstants.NowDateTime);

        builder.Property(u => u.UpdatedAt)
            .HasDefaultValueSql(PersistenceConstants.NowDateTime);
    }
}
