using HrPlatform.Domain.Entities;

namespace HrPlatform.Persistence.Postgre.Abstractions.RoleRepositories;

public interface IAddPermissionForRoleRepository
{
    Task<bool> IsExistPermission(Guid permissionId, CancellationToken cancellationToken);
    Task<bool> IsExistRolePermission(int roleId, Guid permissionId, CancellationToken cancellationToken);
    Task<bool> IsExistRole(int roleId, CancellationToken cancellationToken);
    Task AddRolePermission(RolePermission entity, CancellationToken cancellationToken);
}
