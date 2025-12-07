using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

public class Permission : ITimestampEntity<Guid>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
