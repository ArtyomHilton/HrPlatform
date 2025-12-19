using HrPlatform.Application.UseCases.UserUseCases.RegistrationUseCase;
using HrPlatform.Web.Contracts;
using HrPlatform.Web.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace HrPlatform.Web.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder builder)
    {
        var mapGroup = builder.MapGroup("/api/users");

        mapGroup.MapPost("registration", Registration)
            .Produces(StatusCodes.Status204NoContent)
            .WithDescription("Регистрация пользователя");

        return builder;
    }

    static async Task<IResult> Registration([FromBody] RegistrationRequest request,
        [FromServices] IRegistrationUseCase useCase,
        CancellationToken cancellationToken)
    {
        await useCase.Execute(request.ToModel(), cancellationToken);

        return Results.NoContent();
    }
}