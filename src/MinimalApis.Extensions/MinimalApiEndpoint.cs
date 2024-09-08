using Microsoft.AspNetCore.Routing;

namespace MinimalApis.Extensions;

public abstract class MinimalApiEndpoint
{
    public abstract void Define(IEndpointRouteBuilder builder);
}
