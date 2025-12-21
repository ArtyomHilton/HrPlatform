namespace HrPlatform.Common.Result.Errors;

public class UserNotFoundError : NotFoundError
{
    public UserNotFoundError() : base("UserNotFound") { }
}