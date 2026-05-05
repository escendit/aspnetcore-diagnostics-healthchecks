# Escendit.AspNetCore.Diagnostics.HealthChecks

Standardized Health Checks for ASP.NET Core applications.

## Introduction

This library provides a set of opinionated defaults and extension methods to simplify the configuration of health checks in ASP.NET Core applications, following best practices for health endpoints.

## Features

- **Standardized Endpoints**: Automatically maps health checks to `/.well-known/healthz`, including specialized paths for `live`, `ready`, and `startup`.
- **Custom Response Writer**: Provides a structured JSON response writer by default.
- **Easy Configuration**: Extension methods for `WebApplicationBuilder` and `WebApplication` for one-line setup.

## Installation

Install the package via NuGet:

```bash
dotnet add package Escendit.AspNetCore.Diagnostics.HealthChecks
```

## Usage

### 1. Register Health Checks

In your `Program.cs`, add the health check defaults:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add health check defaults
builder.AddHealthCheckDefaults(checks =>
{
    // Add checks with specific tags
    checks.AddCheck<MyLiveCheck>("live", tags: ["live"]);
    checks.AddCheck<MyReadyCheck>("ready", tags: ["ready"]);
    checks.AddCheck<MyStartupCheck>("startup", tags: ["startup"]);

    // Tags can be combined to include a check in multiple endpoints
    checks.AddCheck<MyCombinedCheck>("combined", tags: ["live", "ready"]);
});
```

> [!NOTE]
> Tags can be combined for a single health check. For example, a check tagged with both `live` and `ready` will be executed by both the `live` and `ready` endpoints.

### 2. Map Health Check Endpoints

Map the standardized endpoints in the request pipeline:

```csharp
var app = builder.Build();

// Use health check defaults
app.UseHealthCheckDefaults();

app.Run();
```

### Endpoints Created

By default, the following endpoints are mapped:

- `/.well-known/healthz`: General health status (includes "self" check).
- `/.well-known/healthz/ready`: Checks tagged with `ready`.
- `/.well-known/healthz/live`: Checks tagged with `live`.
- `/.well-known/healthz/startup`: Checks tagged with `startup`.

## License

Licensed under the [Apache License 2.0](LICENSE).
