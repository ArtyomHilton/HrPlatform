namespace HrPlatform.Domain.Entities.Abstractions;

/// <summary>
/// Базовая сущность с временными метками.
/// </summary>
public class TimeStampEntity : EntityBase
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}
