namespace HrPlatform.Domain.Entities.Abstractions;

/// <summary>
/// Базовая сущность.
/// </summary>
/// <typeparam name="T">Любой тип данных для <see cref="Id"/></typeparam>
public interface IEntity<T>
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    T Id { get; set; }

    /// <summary>
    /// Версия записи в БД.
    /// </summary>
    Guid Version { get; set; }
}

/// <summary>
/// Базовая сущность.
/// </summary>
public interface IEntity 
{

}