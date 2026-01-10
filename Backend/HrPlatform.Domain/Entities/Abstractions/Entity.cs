namespace HrPlatform.Domain.Entities.Abstractions;

/// <summary>
/// Сущность
/// </summary>
public class Entity : EntityBase
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
}
