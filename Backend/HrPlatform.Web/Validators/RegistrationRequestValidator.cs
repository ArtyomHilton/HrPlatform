using FluentValidation;
using HrPlatform.Web.Contracts;

namespace HrPlatform.Web.Validators;

/// <summary>
/// Валидатор для модели <see cref="RegistrationRequest"/>
/// </summary>
public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
{
    /// <summary>
    /// Набор доступных символов для имени пользователя
    /// </summary>
    private readonly string _correctUsernameSymbols = "qwertyuiopasdfghjklzxcvbnm@$_-";

    /// <summary>
    /// Набор доступных символов для пароля
    /// </summary>
    private readonly string _correctPasswordSymbols = @"qwertyuiopasdfghjklzxcvbnm@$_-!#%&*()+={}[]?/\<>";

    public RegistrationRequestValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Username)
            .NotEmpty()
            .WithErrorCode("UsernameEmpty")
            .Must(IsCorrectUsernameFormat)
            .WithErrorCode("NotCorrectUsernameFormat");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithErrorCode("PasswordEmpty")
            .Must(IsCorrectPasswordFormat)
            .WithErrorCode("NotCorrectPasswordFormat");

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithErrorCode("NotCorrectEmailFormat");
    }

    /// <summary>
    /// Проверка корректности символов имени пользователя
    /// </summary>
    /// <param name="username">Имя пользователя</param>
    /// <returns>true - корректно | false - некорректно</returns>
    private bool IsCorrectUsernameFormat(string username)
    {
        foreach (var symbol in username)
        {
            if (!_correctUsernameSymbols.Contains(symbol))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Проверка корректности символов пароля
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <returns>true - корректно | false - некорректно</returns>
    private bool IsCorrectPasswordFormat(string password)
    {
        foreach(var symbol in password)
        {
            if (!_correctPasswordSymbols.Contains(symbol))
            {
                return false;
            }
        }

        return true;
    }
}