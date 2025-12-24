namespace HrPlatform.Common.Result.Errors;

public class RoleExistError : BadRequestError
{
    public RoleExistError() : base("RoleExist") { }
}
