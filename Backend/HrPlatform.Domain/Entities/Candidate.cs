using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

/// <summary>
/// Кандидат
/// </summary>
public class Candidate : ITimestampEntity<Guid>
{
    /// <inheritdoc />
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Фамилия
    /// </summary>
    public string SecondName { get; set; } = string.Empty;

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Идентификатор резюме в файловом хранилище
    /// </summary>
    public Guid CvFileId { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthdayDate { get; set; }

    /// <inheritdoc />
    public DateTime CreatedAt { get; set; }

    /// <inheritdoc />
    public DateTime UpdatedAt { get; set; }
}
