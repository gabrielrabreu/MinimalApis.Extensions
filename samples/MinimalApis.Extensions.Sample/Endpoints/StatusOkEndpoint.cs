using Microsoft.AspNetCore.Http.HttpResults;

namespace MinimalApis.Extensions.Sample.Endpoints;

public class StatusOkEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/Status/Ok", Handle)
            .WithOpenApi()
            .WithTags("Status")
            .ProducesOk<string>();
    }

    private Ok<string> Handle()
    {
        return TypedResults.Ok("MyValue");
    }
}
