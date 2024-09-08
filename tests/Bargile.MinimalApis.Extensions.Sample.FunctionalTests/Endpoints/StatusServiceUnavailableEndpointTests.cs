using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Bargile.MinimalApis.Extensions.Sample.FunctionalTests.Endpoints;

public class StatusServiceUnavailableEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/ServiceUnavailable";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsServiceUnavailable()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().HaveStatusCode(HttpStatusCode.ServiceUnavailable);
    }
}