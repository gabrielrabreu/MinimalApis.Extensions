using FluentAssertions;
using Microsoft.AspNetCore.Routing;
using System.Reflection;

namespace MinimalApis.Extensions.UnitTests;

public class MinimalApiEndpointConfigurationTests
{
    private readonly MinimalApiEndpointConfiguration _configuration = new();

    [Fact]
    public void FromType_ShouldAddToTypeList()
    {
        // Arrange & Act
        _configuration.FromType<MockFirstMinimalApiEndpoint>();

        // Assert
        _configuration.GetEndpoints()
            .Should().HaveCount(1)
            .And.Contain(typeof(MockFirstMinimalApiEndpoint));
    }

    [Fact]
    public void FromAssembly_ShouldAddToTypeList()
    {
        // Arrange & Act
        _configuration.FromAssembly(Assembly.GetExecutingAssembly());

        // Assert
        _configuration.GetEndpoints()
            .Should().HaveCount(3)
            .And.Contain(typeof(MockFirstMinimalApiEndpoint))
            .And.Contain(typeof(MockSecondMinimalApiEndpoint))
            .And.Contain(typeof(MockThirdMinimalApiEndpoint));
    }
}

public class MockFirstMinimalApiEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
    }
}

public class MockSecondMinimalApiEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
    }
}

public class MockThirdMinimalApiEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
    }
}