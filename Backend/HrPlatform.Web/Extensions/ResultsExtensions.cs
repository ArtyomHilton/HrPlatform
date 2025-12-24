using HrPlatform.Common.Result;
using HrPlatform.Common.Result.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HrPlatform.Web.Extensions;

public static class ResultsExtensions
{
    public static IResult ToErrorResponse<T>(this Result<T> results)
    {
        return results.Error switch
        {
            NotFoundError error => Results.NotFound(error.ToProblemDetails()),
            AddUserError error => Results.BadRequest(error.ToProblemDetails()),
            EmailExistError error => Results.BadRequest(error.ToProblemDetails()),
            UsernameExistError error => Results.BadRequest(error.ToProblemDetails),
            UnauthorizedError => Results.Unauthorized(),
            ErrorBase error => Results.StatusCode(error.StatusCode)
        };
    }

    private static ProblemDetails ToProblemDetails(this ErrorBase error) =>
        new ProblemDetails()
        {
            Status = error.StatusCode,
            Detail = error.ErrorCode,
        };
}
