using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

/// <summary>
/// Роль пользователя.
/// </summary>
public class UserRole : IEntity
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Навигационное свойство к User.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// Идентификатор роли.
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Навигационное свойство к Role.
    /// </summary>
    public Role Role { get; set; } = null!;
}