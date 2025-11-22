using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

/// <summary>
/// Роль.
/// </summary>
public class Role : ITimestampEntity<short>
{
    /// <summary>
    /// <inheritdoc />
    /// </summary>
    public short Id { get; set; }

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
}
