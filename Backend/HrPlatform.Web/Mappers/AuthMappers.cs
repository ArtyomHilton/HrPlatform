using HrPlatform.Application.Models;
using HrPlatform.Web.Contracts;

namespace HrPlatform.Web.Mappers;

/// <summary>
/// Маппер пользовательских меоделей
/// </summary>
public static class AuthMappers
{
    public static RegistrationRequestModel ToModel(this RegistrationRequest request) =>
        new RegistrationRequestModel(request.Username, request.Password, request.Email);

    public static LoginRequestModel ToModel(this LoginRequest request) =>
        new LoginRequestModel(request.Email, request.Password);
}
