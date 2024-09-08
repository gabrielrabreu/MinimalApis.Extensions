# MinimalApis.Extensions

![Sonar Quality Gate](https://img.shields.io/sonar/quality_gate/gabrielrabreu_MinimalApis.Extensions?server=https%3A%2F%2Fsonarcloud.io&style=for-the-badge)
![Sonar Coverage](https://img.shields.io/sonar/coverage/gabrielrabreu_MinimalApis.Extensions?server=https%3A%2F%2Fsonarcloud.io&style=for-the-badge)
![GitHub last commit](https://img.shields.io/github/last-commit/gabrielrabreu/MinimalApis.Extensions?style=for-the-badge)
![GitHub Release](https://img.shields.io/github/v/release/gabrielrabreu/MinimalApis.Extensions?style=for-the-badge)

## Overview

MinimalApis.Extensions is a library that has a set of extensions for enhancing and simplifying the development of Minimal APIs in ASP.NET Core.

## What Problem Does This Address?

Minimal APIs in ASP.NET Core streamline API development by removing the need for controllers, resulting in cleaner and more concise code. However, placing all endpoint definitions directly in `Program.cs` can lead to cluttered and hard-to-maintain code, especially as the number of endpoints grows.

### Traditional Approach

In a typical setup, you define endpoints in Program.cs, which can become unwieldy:

```
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/endpoint1", () => "Response 1");
app.MapPost("/api/endpoint2", () => "Response 2");
// More endpoints...

app.Run();
```

### Issue

As more endpoints are added, `Program.cs` can get crowded, making it difficult to manage and maintain.

### Solution

This project addresses this by using a modular approach where each endpoint is defined in its own class. This keeps `Program.cs` clean and makes it easier to manage and scale your API.

## Sample Usage

### Define an Endpoint

Create a class for each endpoint, inheriting from MinimalApiEndpoint. Each class defines a single endpoint:

```
public class GreetUserEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/greet/{name}", (string name) => $"Hello, {name}!")
            .WithOpenApi()
            .WithTags("Greeting")
            .Produces<string>();
    }
}
```

In this example, GreetUserEndpoint handles a simple GET request to greet a user by name.

### Register Endpoints

In `Program.cs`, register all endpoint classes from the current assembly:

```
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Register endpoints from the current assembly
app.RegisterEndpoints(Assembly.GetExecutingAssembly());

app.Run();
```

### Add More Endpoints

To add new endpoints, create additional classes following the same pattern. For example, to add an endpoint for fetching user information:

```
public class UserInfoEndpoint : MinimalApiEndpoint
{
    public override void Define(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/user/{id}", (int id) => $"User ID: {id}")
            .WithOpenApi()
            .WithTags("User")
            .Produces<string>();
    }
}
```

By using this approach, each endpoint is neatly organized in its own class, keeping Program.cs clean and making the codebase more maintainable.

## Getting Started

If you're building an ASP.NET Core Web API you can simply install the [Bargile.MinimalApis.Extensions](https://www.nuget.org/packages/Bargile.MinimalApis.Extensions/) package to get started.

