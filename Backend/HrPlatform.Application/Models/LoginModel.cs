namespace HrPlatform.Application.Models;

/// <summary>
/// Модель логина
/// </summary>
/// <param name="Email">Электронная почта</param>
/// <param name="Password">Пароль</param>
public record LoginModel(string Email, string Password);
