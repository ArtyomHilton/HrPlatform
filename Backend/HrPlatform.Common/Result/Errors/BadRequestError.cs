using Microsoft.AspNetCore.Http;

namespace HrPlatform.Common.Result.Errors;

public class BadRequestError : ErrorBase
{
    public BadRequestError(string errorCode) : base(errorCode, StatusCodes.Status400BadRequest) { }
}
