using HrPlatform.Domain.Entities;
using HrPlatform.Persistence.Postgre.Abstractions.RoleRepositories;
using HrPlatform.Persistence.Postgre.Context;
using Microsoft.EntityFrameworkCore;

namespace HrPlatform.Persistence.Postgre.Repositories.RoleRepositories;

class AddPermissionForRoleRepository(HrPlatformDbContext context) : IAddPermissionForRoleRepository
{
    public async Task AddRolePermission(RolePermission entity, CancellationToken cancellationToken)
    {
        await context.RolePermissions.AddAsync(entity, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsExistRole(int roleId, CancellationToken cancellationToken) =>
        await context.Roles.AnyAsync(r => r.Id == roleId, cancellationToken);

    public async Task<bool> IsExistPermission(Guid permissionId, CancellationToken cancellationToken) =>
        await context.Permissions.AnyAsync(p => p.Id == permissionId, cancellationToken);

    public async Task<bool> IsExistRolePermission(int roleId, Guid permissionId, CancellationToken cancellationToken) =>
        await context.RolePermissions.AnyAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId,
            cancellationToken);
}