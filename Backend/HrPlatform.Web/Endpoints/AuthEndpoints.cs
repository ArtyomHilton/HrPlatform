using HrPlatform.Application.UseCases.AuthUseCases.Login;
using HrPlatform.Application.UseCases.AuthUseCases.Registration;
using HrPlatform.Common.Result.Errors;
using HrPlatform.Web.Contracts;
using HrPlatform.Web.Contracts.Response;
using HrPlatform.Web.Extensions;
using HrPlatform.Web.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace HrPlatform.Web.Endpoints;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder builder)
    {
        var mapGroup = builder.MapGroup("/api/auth");

        mapGroup.MapPost("registration", Registration)
            .Produces(StatusCodes.Status204NoContent)
            .WithDescription("Регистрация пользователя");

        mapGroup.MapPost("login", Login)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized)
            .WithDescription("Авторизация");

        return builder;
    }

    private static async Task<IResult> Registration([FromBody] RegistrationRequest request,
        [FromServices] IRegistrationUseCase useCase,
        CancellationToken cancellationToken)
    {
        var result = await useCase.Execute(request.ToModel(), cancellationToken);

        if (result.IsFailed)
            return result.ToErrorResponse();

        return Results.NoContent();
    }

    private static async Task<IResult> Login([FromBody] LoginRequest request,
        [FromServices] ILoginUseCase useCase,
        CancellationToken cancellationToken)
    {
        var result = await useCase.Execute(request.ToModel(), cancellationToken);

        if (result.IsFailed)
            return result.ToErrorResponse();

        return Results.Ok();
    }
}