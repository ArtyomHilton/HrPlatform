using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

/// <summary>
/// Разрешение
/// </summary>
public class Persistence : Entity
{
    /// <summary>
    /// Код разрешения
    /// </summary>
    public string PersistenceCode { get; set; } = null!;

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; } = null!;
    public ICollection<RolePersistence> RolePersistences { get; set; } = [];
}
