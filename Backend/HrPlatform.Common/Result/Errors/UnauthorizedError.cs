using Microsoft.AspNetCore.Http;

namespace HrPlatform.Common.Result.Errors;

public class UnauthorizedError : ErrorBase
{
    public UnauthorizedError() : base("Unauthorized", StatusCodes.Status401Unauthorized)
    {
    }
}
