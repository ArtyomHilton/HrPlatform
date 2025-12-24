using HrPlatform.Application.Models.RoleModels;
using HrPlatform.Domain.Entities;

namespace HrPlatform.Application.Mappers;

public static class RoleMappers
{
    public static Role ToEntity(this CreateRoleRequestModel model) =>
        new Role
        {
            Name = model.name,
        };
}
