using HrPlatform.Application.Models;
using HrPlatform.Common.Result;

namespace HrPlatform.Application.UseCases.AuthUseCases.Login;

/// <summary>
/// Логин
/// </summary>
public interface ILoginUseCase
{
    Task<Result<LoginResponseModel>> Execute(LoginRequestModel model, CancellationToken cancellationToken = default);
}
