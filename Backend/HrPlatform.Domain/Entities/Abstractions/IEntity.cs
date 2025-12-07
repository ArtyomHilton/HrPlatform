namespace HrPlatform.Domain.Entities.Abstractions;

/// <summary>
/// Базовая сущность.
/// </summary>
/// <typeparam name="T">Любой тип данных для <see cref="Id"/></typeparam>
public interface IEntity<T> : IEntity
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    T Id { get; set; }
}

/// <summary>
/// Базовая сущность.
/// </summary>
public interface IEntity 
{

}