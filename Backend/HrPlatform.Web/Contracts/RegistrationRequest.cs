namespace HrPlatform.Web.Contracts;

/// <summary>
/// DTO регистрации пользователя
/// </summary>
/// <param name="Username">Имя пользователя</param>
/// <param name="Password">Пароль</param>
/// <param name="Email">Электронная почта</param>
public record RegistrationRequest(string Username, string Password, string Email);
