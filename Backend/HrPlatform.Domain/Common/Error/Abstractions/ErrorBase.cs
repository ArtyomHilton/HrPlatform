namespace HrPlatform.Domain.Common.Error.Abstractions;

/// <summary>
/// Базовая ошибка
/// </summary>
public abstract class ErrorBase
{
    /// <summary>
    /// Код ошибки
    /// </summary>
    public string ErrorCode { get; init; } = "ServerError";
    
    /// <summary>
    /// Статус код
    /// </summary>
    public int StatusCode { get; init; } = 500;

    protected ErrorBase(int statusCode, string errorCode)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }
}
