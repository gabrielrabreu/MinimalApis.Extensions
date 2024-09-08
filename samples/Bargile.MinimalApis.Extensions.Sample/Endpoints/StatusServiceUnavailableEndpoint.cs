using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bargile.MinimalApis.Extensions.Sample.Endpoints;

public class StatusServiceUnavailableEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/ServiceUnavailable", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .ProducesServiceUnavailable();
    }

    private ProblemHttpResult Handle()
    {
        return TypedResults.Problem(new ProblemDetails
        {
            Title = "Service unavailable.",
            Detail = "Details",
            Status = StatusCodes.Status503ServiceUnavailable
        });
    }
}
