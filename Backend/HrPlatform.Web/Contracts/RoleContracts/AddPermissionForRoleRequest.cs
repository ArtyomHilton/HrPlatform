namespace HrPlatform.Web.Contracts.RoleContracts;

public record AddPermissionForRoleRequest(int RoleId, Guid PermissionId);
