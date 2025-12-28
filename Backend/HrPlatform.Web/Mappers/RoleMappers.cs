using HrPlatform.Application.Models.RoleModels;
using HrPlatform.Web.Contracts.RoleContracts;

namespace HrPlatform.Web.Mappers;

public static class RoleMappers
{
    public static CreateRoleRequestModel ToModel(this CreateRoleRequest request) =>
        new CreateRoleRequestModel(request.name);

    public static AddPermissionForRoleModel ToModel(this AddPermissionForRoleRequest request) =>
        new AddPermissionForRoleModel(request.RoleId, request.PermissionId);
}
