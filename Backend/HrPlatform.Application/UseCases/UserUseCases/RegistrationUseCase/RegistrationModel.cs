using HrPlatform.Domain.Entities;

namespace HrPlatform.Application.UseCases.UserUseCases.RegistrationUseCase;

/// <summary>
/// Модель регистрации пользователя
/// </summary>
public record RegistrationModel
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

    public static explicit operator User(RegistrationModel model)
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
