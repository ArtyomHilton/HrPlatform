using Microsoft.AspNetCore.Http;

namespace HrPlatform.Common.Result.Errors;

public class NotFoundError : ErrorBase
{
    public NotFoundError(string errorCode) : base(errorCode, StatusCodes.Status404NotFound)
    {
        ErrorCode = errorCode;
    }
}
