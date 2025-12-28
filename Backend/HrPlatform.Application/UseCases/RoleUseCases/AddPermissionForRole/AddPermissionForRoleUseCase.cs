using HrPlatform.Application.Models.RoleModels;
using HrPlatform.Common.Result;
using HrPlatform.Common.Result.Errors;
using HrPlatform.Domain.Entities;
using HrPlatform.Persistence.Postgre.Abstractions.RoleRepositories;
using Microsoft.Extensions.Logging;

namespace HrPlatform.Application.UseCases.RoleUseCases.AddPermissionForRole;

class AddPermissionForRoleUseCase(IAddPermissionForRoleRepository repository, ILogger<AddPermissionForRoleUseCase> logger) : IAddPermissionForRoleUseCase
{
    public async Task<Result> Execute(AddPermissionForRoleModel model, CancellationToken cancellationToken)
    {
        if (!await repository.IsExistPermission(model.PermissionId, cancellationToken))
            return Result.Failed(new PermissionNotFoundError());

        if (!await repository.IsExistRole(model.RoleId, cancellationToken))
            return Result.Failed(new RoleNotFoundError());

        if (await repository.IsExistRolePermission(model.RoleId, model.PermissionId, cancellationToken))
            return Result.Failed(new RoleContainsPermissionError());

        await repository.AddRolePermission(new RolePermission()
        {
            RoleId = model.RoleId,
            PermissionId = model.PermissionId
        },
        cancellationToken);

        return Result.Success();
    }
}
