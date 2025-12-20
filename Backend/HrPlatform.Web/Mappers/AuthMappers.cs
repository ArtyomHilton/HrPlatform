using HrPlatform.Application.Models;
using HrPlatform.Web.Contracts;

namespace HrPlatform.Web.Mappers;

/// <summary>
/// Маппер пользовательских меоделей
/// </summary>
public static class AuthMappers
{
    public static RegistrationModel ToModel(this RegistrationRequest request) =>
        new RegistrationModel(request.Username, request.Password, request.Email);

    public static LoginModel ToModel(this LoginRequest request) =>
        new LoginModel(request.Email, request.Password);
}
