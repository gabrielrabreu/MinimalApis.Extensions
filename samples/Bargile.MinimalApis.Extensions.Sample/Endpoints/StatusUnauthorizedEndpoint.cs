using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bargile.MinimalApis.Extensions.Sample.Endpoints;

public class StatusUnauthorizedEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/Unauthorized", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .ProducesUnauthorized();
    }

    private ProblemHttpResult Handle()
    {
        return TypedResults.Problem(new ProblemDetails
        {
            Title = "Unauthorized.",
            Detail = "Details",
            Status = StatusCodes.Status401Unauthorized
        });
    }
}