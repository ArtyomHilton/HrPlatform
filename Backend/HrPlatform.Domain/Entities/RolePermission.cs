using HrPlatform.Domain.Entities.Abstractions;

namespace HrPlatform.Domain.Entities;

public class RolePermission : IEntity
{
    public int RoleId { get; set; }

    public Role Role { get; set; } = null!;

    public Guid PermissionId { get; set; }

    public Permission Permission { get; set; } = null!;
}
