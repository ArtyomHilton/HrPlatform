using HrPlatform.Domain.Common.Error.Abstractions;

namespace HrPlatform.Domain.Common;

/// <summary>
/// Результат
/// </summary>
public class Result
{
    /// <summary>
    /// Ошибка
    /// </summary>
    public ErrorBase? Error { get; init; }

    /// <summary>
    /// Результат
    /// </summary>
    private bool _result { get; init; }

    /// <summary>
    /// Успешный
    /// </summary>
    public bool IsSuccess => _result;

    /// <summary>
    /// Не успешный
    /// </summary>
    public bool IsFailure => !_result;

    protected Result(ErrorBase? error, bool result)
    {
        Error = error;
        _result = result;
    }

    /// <summary>
    /// Создает результат с ошибкой
    /// </summary>
    /// <param name="error">Любая ошибка которая является потомком от <see cref="ErrorBase"/></param>
    /// <returns><see cref="Result"/></returns>
    public static Result Failure(ErrorBase error) =>
        new Result(error, false);

    /// <summary>
    /// Создает результат без ошибки
    /// </summary>
    /// <returns><see cref="Result"/></returns>
    public static Result Success() =>
        new Result(default, true);
}

/// <summary>
/// Результат со значением
/// </summary>
/// <typeparam name="T">Любой тип</typeparam>
public class Result<T> : Result
{
    /// <summary>
    /// Значение
    /// </summary>
    public T? Value { get; init; }

    protected Result(T? value, ErrorBase? error, bool result) : base(error, result)
    {
        Value = value;
    }

    /// <summary>
    /// Создает результат с ошибкой
    /// </summary>
    /// <param name="error">Любая ошибка которая является потомком от <see cref="ErrorBase"/></param>
    /// <returns><see cref="Result{T}"/></returns>
    public static new Result<T> Failure(ErrorBase error) =>
        new Result<T>(default, error, false);

    /// <summary>
    /// Создает результат без ошибки
    /// </summary>
    /// <param name="value">Значение</param>
    /// <returns><see cref="Result{T}"/></returns>
    public static Result<T> Success(T value) =>
        new Result<T>(value, default, true);
}