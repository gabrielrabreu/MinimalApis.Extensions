using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Bargile.MinimalApis.Extensions.Sample.FunctionalTests.Endpoints;

public class StatusOkEndpointTests(WebApplicationFactory<IWebMarker> factory) : IClassFixture<WebApplicationFactory<IWebMarker>>
{
    private const string ENDPOINT = "/Status/Ok";

    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task ReturnsOk()
    {
        var response = await _client.PostAsync(ENDPOINT, null);
        response.Should().HaveStatusCode(HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();
        content.Trim('\"').Should().Be("MyValue");
    }
}
