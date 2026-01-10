using HrPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrPlatform.Infrastructure.Database.Configurations;

class PersistenceConfiguration : IEntityTypeConfiguration<Persistence>
{
    public void Configure(EntityTypeBuilder<Persistence> builder)
    {
        builder.ToTable(nameof(Persistence));

        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.PersistenceCode)
            .IsUnique();
        builder.Property(p => p.PersistenceCode)
            .IsRequired();

        builder.Property(p => p.Description)
            .IsRequired();
    }
}
