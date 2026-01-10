using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

/// <summary>
/// Связывающая сущность между ролью и разрешениями
/// </summary>
public class RolePersistence : EntityBase
{
    /// <summary>
    /// Идентификатор роли
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// Идентификатор разрешения
    /// </summary>
    public Guid PersistenceId { get; set; }
    public Role Role { get; set; } = new Role();
    public Persistence Persistence { get; set; } = new Persistence();
}
