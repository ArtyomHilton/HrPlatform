namespace HrPlatform.Application.Models;

/// <summary>
/// Модель логина
/// </summary>
/// <param name="Email">Электронная почта</param>
/// <param name="Password">Пароль</param>
public record LoginRequestModel(string Email, string Password);
