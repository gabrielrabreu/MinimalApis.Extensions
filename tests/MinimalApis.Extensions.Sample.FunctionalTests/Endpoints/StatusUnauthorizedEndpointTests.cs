using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace MinimalApis.Extensions.Sample.FunctionalTests.Endpoints;

public class StatusUnauthorizedEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/Unauthorized";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsUnauthorized()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().HaveStatusCode(HttpStatusCode.Unauthorized);
    }
}
