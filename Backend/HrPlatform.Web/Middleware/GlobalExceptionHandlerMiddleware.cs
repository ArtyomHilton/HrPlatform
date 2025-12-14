using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace HrPlatform.Web.Middleware;

public class GlobalExceptionHandlerMiddleware : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = exception switch
        {
            NpgsqlException => CreateProblemDetails(exception.GetType().Name, "NotDbConnection", StatusCodes.Status500InternalServerError, exception.HelpLink),
            Exception => CreateProblemDetails(exception.GetType().Name, exception.Message, StatusCodes.Status500InternalServerError, exception.HelpLink)
        };

        _logger.LogError("Application error: {ErrorType} | Message {Message}", exception.GetType().Name, exception.Message);

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private ProblemDetails CreateProblemDetails(string title, string detail, int statusCode, string? type) =>
        new ProblemDetails()
        {
            Title = title,
            Detail = detail,
            Status = statusCode,
            Type = type,
        };
}
