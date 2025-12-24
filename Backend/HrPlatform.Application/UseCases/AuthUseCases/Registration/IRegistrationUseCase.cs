using HrPlatform.Application.Models;
using HrPlatform.Common.Result;

namespace HrPlatform.Application.UseCases.AuthUseCases.Registration;

/// <summary>
/// Регистрация пользователя
/// </summary>
public interface IRegistrationUseCase
{
    public Task<Result<RegisterResponseModel>> Execute(RegistrationRequestModel model, CancellationToken cancellationToken);
}
