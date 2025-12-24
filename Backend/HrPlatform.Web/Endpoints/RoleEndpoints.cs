using HrPlatform.Application.UseCases.RoleUseCases.CreateRole;
using HrPlatform.Web.Contracts.RoleContracts;
using HrPlatform.Web.Extensions;
using HrPlatform.Web.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace HrPlatform.Web.Endpoints;

public static class RoleEndpoints
{
    public static IEndpointRouteBuilder MapRoleEndpoints(this IEndpointRouteBuilder builder)
    {
        var mapGroup = builder.MapGroup("/api/role");

        mapGroup.MapPost("/add", CreateRole)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithDescription("Добавление роли");

        return builder;
    }

    private static async Task<IResult> CreateRole([FromBody] CreateRoleRequest request,
        [FromServices] ICreateRoleUseCase useCase,
        CancellationToken cancellationToken)
    {
        var result = await useCase.Execute(request.ToModel(), cancellationToken);

        if (result.IsFailed)
            return result.ToErrorResponse();

        return Results.Created();
    }
}
