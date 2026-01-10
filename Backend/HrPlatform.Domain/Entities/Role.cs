using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

/// <summary>
/// Роль
/// </summary>
public class Role : Entity
{
    /// <summary>
    /// Название роли
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = [];
    public ICollection<RolePersistence> RolePersistences { get; set; } = [];
}
