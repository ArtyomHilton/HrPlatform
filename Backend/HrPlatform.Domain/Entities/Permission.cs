using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

/// <summary>
/// Разрешение.
/// </summary>
public class Permission : ITimestampEntity<Guid>
{
    /// <inheritdoc />
    public Guid Id { get; set; }

    /// Код разрешения.
    public string Code { get; set; } = string.Empty;

    /// <inheritdoc />
    public DateTime CreatedAt { get; set; }

    /// <inheritdoc />
    public DateTime UpdatedAt { get; set; }

    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
