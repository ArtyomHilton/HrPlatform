using HrPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrPlatform.Infrastructure.Database.Configurations;

class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable(nameof(Position));

        builder.HasKey(p => p.Id);

        builder.Property(p => p.PositionName)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasDefaultValue(null);
    }
}