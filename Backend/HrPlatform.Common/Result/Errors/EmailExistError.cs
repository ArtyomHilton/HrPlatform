using Microsoft.AspNetCore.Http;

namespace HrPlatform.Common.Result.Errors;

public class EmailExistError : ErrorBase
{
    public EmailExistError() : base("EmailExist", StatusCodes.Status400BadRequest) { }
}
