using HrPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrPlatform.Persistence.Postgre.Configurations;

public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.ToTable(nameof(Candidate));

        builder.HasKey(c => c.Id);

        builder.Property(c => c.FirstName)
            .IsRequired();

        builder.Property(c => c.SecondName)
            .IsRequired();

        builder.Property(c => c.Patronymic)
            .HasDefaultValue(null);

        builder.Property(c => c.CvFileId)
            .HasDefaultValue(null);
        builder.HasIndex(c => c.CvFileId)
            .IsUnique();

        builder.Property(c=> c.BirthdayDate)
            .HasDefaultValue(null);

        builder.Property(u => u.CreatedAt)
            .HasDefaultValueSql(PersistenceConstants.NowDateTime);

        builder.Property(u => u.UpdatedAt)
            .HasDefaultValueSql(PersistenceConstants.NowDateTime);

        builder.Property<uint>("Version")
            .IsRowVersion();
    }
}
