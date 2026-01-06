using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

/// <summary>
/// Должность
/// </summary>
public sealed class Position : TimeStampEntity
{
    /// <summary>
    /// Название должности
    /// </summary>
    public string PositionName { get; set; } = null!;

    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Навигационное свойство к пользователям
    /// </summary>
    public ICollection<User> Users = [];
}