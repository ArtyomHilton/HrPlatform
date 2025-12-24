using Microsoft.AspNetCore.Http;

namespace HrPlatform.Common.Result.Errors;

public class EmailExistError : BadRequestError
{
    public EmailExistError() : base("EmailExist") { }
}
