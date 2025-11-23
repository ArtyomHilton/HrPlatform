using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

/// <summary>
/// Роль.
/// </summary>
public class Role : ITimestampEntity<int>
{
    /// <summary>
    /// <inheritdoc />
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// <inheritdoc />
    /// </summary>
    public Guid Version { get; set; }

    /// <summary>
    /// <inheritdoc />
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// <inheritdoc />
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Навигационное свойство к UserRole.
    /// </summary>
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
