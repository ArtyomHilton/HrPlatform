using HrPlatform.Application.Abstractions;
using HrPlatform.Application.Models;
using HrPlatform.Common.Result;
using HrPlatform.Common.Result.Errors;
using HrPlatform.Persistence.Postgre.Abstractions;

namespace HrPlatform.Application.UseCases.AuthUseCases.Login;

/// <summary>
/// <inheritdoc cref="ILoginUseCase"/>
/// </summary>
/// <param name="repository"><see cref="ILoginUserRepository"/></param>
/// <param name="passwordHashedService"><see cref="IPasswordHashedService"/></param>
class LoginUseCase(ILoginUserRepository repository, IPasswordHashedService passwordHashedService) : ILoginUseCase
{
    public async Task<Result<LoginResponseModel>> Execute(LoginRequestModel model, CancellationToken cancellationToken = default)
    {
        var user = await repository.GetUserByEmailAsync(model.Email, cancellationToken);

        if ((user is null))
            return Result<LoginResponseModel>.Failed(new UnauthorizedError());

        if (!passwordHashedService.Verify(user.PasswordHash, model.Password))
            return Result<LoginResponseModel>.Failed(new UnauthorizedError());

        return Result<LoginResponseModel>.Success(new LoginResponseModel(user.Id, user.Username, user.Email));
    }
}