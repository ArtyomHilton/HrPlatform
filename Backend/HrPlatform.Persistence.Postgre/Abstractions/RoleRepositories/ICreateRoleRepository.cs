using HrPlatform.Domain.Entities;

namespace HrPlatform.Persistence.Postgre.Abstractions.RoleRepositories;

public interface ICreateRoleRepository
{
    Task<int> AddRoleAsync(Role role, CancellationToken cancellationToken);
    Task<bool> IsExistRoleAsync(string name, CancellationToken cancellationToken);
}
