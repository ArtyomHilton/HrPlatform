using HrPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrPlatform.Persistence.Postgre.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable(nameof(UserRole));

        builder.HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
