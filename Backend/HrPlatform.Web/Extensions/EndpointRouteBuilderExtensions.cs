using HrPlatform.Web.Endpoints;

namespace HrPlatform.Web.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapAuthEndpoints();

        return builder;
    }
}