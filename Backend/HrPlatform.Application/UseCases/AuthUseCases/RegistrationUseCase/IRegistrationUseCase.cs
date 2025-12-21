using HrPlatform.Application.Models;
using HrPlatform.Common.Result;

namespace HrPlatform.Application.UseCases.AuthUseCases.RegistrationUseCase;

/// <summary>
/// Регистрация пользователя
/// </summary>
public interface IRegistrationUseCase
{
    public Task<Result<RegisterResponseModel>> Execute(RegistrationModel model, CancellationToken cancellationToken);
}
