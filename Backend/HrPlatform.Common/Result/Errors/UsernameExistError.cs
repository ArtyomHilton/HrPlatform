namespace HrPlatform.Common.Result.Errors;

public class UsernameExistError : BadRequestError
{
    public UsernameExistError() : base("UsernameExist") { }
}