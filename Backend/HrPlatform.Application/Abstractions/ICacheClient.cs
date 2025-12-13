namespace HrPlatform.Application.Abstractions;

/// <summary>
/// Клиент кэширования
/// </summary>
public interface ICacheClient
{
    /// <summary>
    /// Добавить значение в кэш
    /// </summary>
    /// <typeparam name="T">Любой тип</typeparam>
    /// <param name="key">Ключ</param>
    /// <param name="value">Значение</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Результат добавлениея true | false</returns>
    Task<bool> SetAsync<T>(string key, T value, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить значение из кэша
    /// </summary>
    /// <typeparam name="T">Любой тип</typeparam>
    /// <param name="key">Ключ</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Значение типа <typeparamref name="T"/> или null</returns>
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удалить значение из кэша
    /// </summary>
    /// <param name="key">Ключ</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Результат удаления true | false</returns>
    Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка наличия ключа в кэше
    /// </summary>
    /// <param name="key">Ключ</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>true - содержится | false - нет</returns>
    Task<bool> ContainsAsync(string key, CancellationToken cancellationToken = default) ;
}
