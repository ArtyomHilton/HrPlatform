using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

/// <summary>
/// Пользователь.
/// </summary>
public class User : ITimestampEntity<Guid>
{
    /// <summary>
    /// <inheritdoc />
    /// </summary>
    public Guid Id { get; set; }

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