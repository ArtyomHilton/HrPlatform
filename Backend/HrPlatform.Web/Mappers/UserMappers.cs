using HrPlatform.Application.UseCases.UserUseCases.RegistrationUseCase;
using HrPlatform.Web.Contracts;

namespace HrPlatform.Web.Mappers;

public static class UserMappers
{
    public static RegistrationModel ToModel(this RegistrationRequest request) =>
        new RegistrationModel(request.Username, request.Password, request.Email);
}
