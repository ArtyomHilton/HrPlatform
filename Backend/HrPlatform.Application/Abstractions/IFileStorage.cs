namespace HrPlatform.Application.Abstractions;

/// <summary>
/// Абстракция файлового хранилища
/// </summary>
public interface IFileStorage
{
    /// <summary>
    /// Сохранить файл в хранилище
    /// </summary>
    /// <param name="bucketName">Имя бакета</param>
    /// <param name="objectName">Имя объекта</param>
    /// <param name="fileName">Имя файла</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Task"/> и статус сохранения</returns>
    Task<bool> PutFile(string bucketName, string objectName, Stream fileStream, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удалить файл из хранилища
    /// </summary>
    /// <param name="bucketName">Имя бакета</param>
    /// <param name="objectName">Имя объекта</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Task"/></returns>
    Task DeleteFile(string bucketName, string objectName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить временную ссылку на файл.
    /// </summary>
    /// <param name="bucketName">Имя бакета</param>
    /// <param name="objectName">Имя объекта</param>
    /// <param name="expiry">Время жизни ссылки</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="Uri"/></returns>
    Task<Uri> GetPresigned(string bucketName, string objectName, int expiry, CancellationToken cancellationToken = default);
}
