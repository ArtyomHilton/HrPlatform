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
    /// Имя пользователя.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Электронная почта.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Хэш пароля.
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

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