
using HrPlatform.Application.Abstractions;
using HrPlatform.Application.Models;
using HrPlatform.Common.Result;
using HrPlatform.Common.Result.Errors;
using HrPlatform.Persistence.Postgre.Context;
using Microsoft.EntityFrameworkCore;

namespace HrPlatform.Application.UseCases.AuthUseCases.LoginUseCase;

/// <summary>
/// <inheritdoc cref="ILoginUseCase"/>
/// </summary>
/// <param name="context"><see cref="HrPlatformDbContext"/></param>
/// <param name="passwordHashedService"><see cref="IPasswordHashedService"/></param>
class LoginUseCase(HrPlatformDbContext context, IPasswordHashedService passwordHashedService) : ILoginUseCase
{
    public async Task<Result<UserLoginModel>> Execute(LoginModel model, CancellationToken cancellationToken = default)
    {
        var user = await context.Users.Select(x => new
        {
            Id = x.Id,
            Username = x.Username,
            Email = x.Email,
            PasswordHash = x.PasswordHash,
        }).FirstOrDefaultAsync(x => x.Email == model.Email, cancellationToken);

        if ((user is null))
        {
            return Result<UserLoginModel>.Failed(new NotFoundError("UserNotFound"));
        }

        if (!passwordHashedService.Verify(user.PasswordHash, model.Password))
        {
            return Result<UserLoginModel>.Failed(new UnauthorizedError());
        }
    }
}
