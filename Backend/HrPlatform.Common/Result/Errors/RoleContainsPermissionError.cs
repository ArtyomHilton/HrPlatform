namespace HrPlatform.Common.Result.Errors;

public class RoleContainsPermissionError : BadRequestError
{
    public RoleContainsPermissionError() : base("RoleContainsPermission") { }
}
