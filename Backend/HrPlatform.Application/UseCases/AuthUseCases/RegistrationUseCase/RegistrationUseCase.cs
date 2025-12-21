using HrPlatform.Application.Abstractions;
using HrPlatform.Application.Models;
using HrPlatform.Common.Result;
using HrPlatform.Common.Result.Errors;
using HrPlatform.Domain.Entities;
using HrPlatform.Persistence.Postgre.Abstractions;

namespace HrPlatform.Application.UseCases.AuthUseCases.RegistrationUseCase;

class RegistrationUseCase(IRegisterUserRepository repository, IPasswordHashedService hashedService) : IRegistrationUseCase
{
    public async Task<Result<RegisterResponseModel>> Execute(RegistrationModel model, CancellationToken cancellationToken)
    {
        if (await repository.IsExistEmailAsync(model.Email, cancellationToken))
            return Result<RegisterResponseModel>.Failed(new EmailExistError());

        if (await repository.IsExistUsernameAsync(model.Username, cancellationToken))
            return Result<RegisterResponseModel>.Failed(new UsernameExistError());

        model.Password = hashedService.Hash(model.Password);

        var entity = await repository.AddUserAsync((User)model, cancellationToken);

        if (entity is null)
            return Result<RegisterResponseModel>.Failed(new AddUserError());

        return Result<RegisterResponseModel>.Success(new RegisterResponseModel(entity.Id));
    }
}
