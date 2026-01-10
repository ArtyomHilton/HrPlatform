using HrPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrPlatform.Infrastructure.Database.Configurations;

class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName)
            .IsRequired();

        builder.Property(u => u.SecondName)
            .IsRequired();

        builder.Property(u => u.Patronymic)
            .HasDefaultValue(null);

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.Property(u => u.PositionId)
            .IsRequired();

        builder.Property(u => u.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql(DatabaseConstants.SQLFunction.NowDateTime);

        builder.Property(u => u.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql(DatabaseConstants.SQLFunction.NowDateTime);

        builder.HasOne(u => u.Position)
            .WithMany(p => p.Users)
            .HasForeignKey(u => u.PositionId);
    }
}
