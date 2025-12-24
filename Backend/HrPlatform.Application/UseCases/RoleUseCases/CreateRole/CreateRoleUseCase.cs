using HrPlatform.Application.Mappers;
using HrPlatform.Application.Models.RoleModels;
using HrPlatform.Common.Result;
using HrPlatform.Common.Result.Errors;
using HrPlatform.Persistence.Postgre.Abstractions.RoleRepositories;

namespace HrPlatform.Application.UseCases.RoleUseCases.CreateRole;

class CreateRoleUseCase(ICreateRoleRepository repository) : ICreateRoleUseCase
{
    public async Task<Result<int>> Execute(CreateRoleRequestModel model, CancellationToken cancellationToken)
    {
        if (await repository.IsExistRoleAsync(model.name, cancellationToken))
            return Result<int>.Failed(new RoleExistError());

        return Result<int>.Success(await repository.AddRoleAsync(model.ToEntity(), cancellationToken));
    }
}
