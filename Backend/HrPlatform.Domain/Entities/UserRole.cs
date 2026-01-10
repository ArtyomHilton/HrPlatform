using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

/// <summary>
/// Связывающая сущность между пользователем и ролями
/// </summary>
public class UserRole : EntityBase
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Идентификатор роли
    /// </summary>
    public Guid RoleId { get; set; }
    public User User { get; set; } = new User();
    public Role Role { get; set; } = new Role();
}
