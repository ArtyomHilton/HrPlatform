using HrPlatform.Application.Models.RoleModels;
using HrPlatform.Common.Result;

namespace HrPlatform.Application.UseCases.RoleUseCases.AddPermissionForRole;

public interface IAddPermissionForRoleUseCase
{
    Task<Result> Execute(AddPermissionForRoleModel model, CancellationToken cancellationToken);
}
