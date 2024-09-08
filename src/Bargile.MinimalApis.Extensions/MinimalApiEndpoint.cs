using Microsoft.AspNetCore.Routing;

namespace Bargile.MinimalApis.Extensions;

public abstract class MinimalApiEndpoint
{
    public abstract void Define(IEndpointRouteBuilder builder);
}
