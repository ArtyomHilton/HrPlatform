using HrPlatform.Application.Models.RoleModels;
using HrPlatform.Common.Result;

namespace HrPlatform.Application.UseCases.RoleUseCases.CreateRole;

public interface ICreateRoleUseCase
{
    public Task<Result<int>> Execute(CreateRoleRequestModel model, CancellationToken cancellationToken);
}
