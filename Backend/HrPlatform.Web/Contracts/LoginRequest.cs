namespace HrPlatform.Web.Contracts;

/// <summary>
/// DTO для логина.
/// </summary>
/// <param name="Email">Электронная почта</param>
/// <param name="Password">Пароль</param>
public record LoginRequest(string Email, string Password);