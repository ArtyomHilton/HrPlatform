using Microsoft.AspNetCore.Http;

namespace HrPlatform.Common.Result.Errors;

public abstract class ErrorBase
{
    public string ErrorCode { get; init; }
    public int StatusCode { get; }

    protected ErrorBase(string errorCode = "InternalServerError", int statusCode = StatusCodes.Status500InternalServerError)
    {
        ErrorCode = errorCode;
        StatusCode = statusCode;    
    }
}