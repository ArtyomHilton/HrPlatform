using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

/// <summary>
/// Пользователь
/// </summary>
public sealed class User : TimeStampEntity
{
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Фамилия
    /// </summary>
    public string SecondName { get; set; } = null!;

    /// <summary>
    /// Отчетсво
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Хэш пароля
    /// </summary>
    public string PasswordHash { get; set; } = null!;

    /// <summary>
    /// Идентификатор позиции
    /// </summary>
    public Guid PositionId { get; set; }

    /// <summary>
    /// Навигационное свойство к позиции
    /// </summary>
    public Position Position { get; set; } = new Position();
    public ICollection<UserRole> UserRoles { get; set; } = [];
}