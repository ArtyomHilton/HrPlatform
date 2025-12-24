using HrPlatform.Domain.Entities;
using HrPlatform.Persistence.Postgre.Abstractions.RoleRepositories;
using HrPlatform.Persistence.Postgre.Context;
using Microsoft.EntityFrameworkCore;

namespace HrPlatform.Persistence.Postgre.Repositories.RoleRepositories;

class CreateRoleRepository(HrPlatformDbContext context) : ICreateRoleRepository
{
    public async Task<int> AddRoleAsync(Role role, CancellationToken cancellationToken)
    {
        var entry = await context.Roles.AddAsync(role, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return entry.Entity.Id;
    }

    public async Task<bool> IsExistRoleAsync(string name, CancellationToken cancellationToken) =>
        await context.Roles.AnyAsync(x => x.Name == name, cancellationToken);
}
