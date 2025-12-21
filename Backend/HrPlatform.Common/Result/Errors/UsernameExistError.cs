using Microsoft.AspNetCore.Http;

namespace HrPlatform.Common.Result.Errors;

public class UsernameExistError : ErrorBase
{
    public UsernameExistError() : base("UsernameExist", StatusCodes.Status400BadRequest) { }
}