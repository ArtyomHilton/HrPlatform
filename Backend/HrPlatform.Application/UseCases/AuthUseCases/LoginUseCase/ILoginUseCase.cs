using HrPlatform.Application.Models;
using HrPlatform.Common.Result;

namespace HrPlatform.Application.UseCases.AuthUseCases.LoginUseCase;

/// <summary>
/// Логин
/// </summary>
public interface ILoginUseCase
{
    Task<Result<UserLoginModel>> Execute(LoginModel model, CancellationToken cancellationToken = default);
}
