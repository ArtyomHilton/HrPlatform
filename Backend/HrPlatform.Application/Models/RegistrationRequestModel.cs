using HrPlatform.Domain.Entities;

namespace HrPlatform.Application.Models;

/// <summary>
/// Модель регистрации пользователя
/// </summary>
public record RegistrationRequestModel
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Username { get; set; } = null!;

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; set; } = null!;

    public RegistrationRequestModel(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
    }

    public static explicit operator User(RegistrationRequestModel model)
    {
        ArgumentNullException.ThrowIfNull(model);

        return new User
        {
            Username = model.Username,
            PasswordHash = model.Password,
            Email = model.Email,
        };
    }
}
