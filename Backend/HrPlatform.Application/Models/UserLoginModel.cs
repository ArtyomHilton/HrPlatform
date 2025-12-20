namespace HrPlatform.Application.Models;

/// <summary>
/// Данные пользователя при логине.
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Username">Имя пользователя</param>
/// <param name="Email">Электронная почта</param>
public class UserLoginModel(Guid Id, string Username, string Email);
