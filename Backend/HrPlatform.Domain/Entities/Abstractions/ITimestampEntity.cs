namespace HrPlatform.Domain.Entities.Abstractions;

/// <summary>
/// Базовая сущность с отслеживанием времени.
/// </summary>
/// <typeparam name="T">Любой тип</typeparam>
public interface ITimestampEntity<T> : IEntity<T>
{
    /// <summary>
    /// Дата создания.
    /// </summary>
    DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата обновления.
    /// </summary>
    DateTime UpdatedAt { get; set; }
}
