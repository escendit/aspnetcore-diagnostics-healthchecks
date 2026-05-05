// Licensed to the Escendit GmbH under one or more agreements.
// The Escendit GmbH licenses this file to you under the Apache License 2.0.

namespace Escendit.AspNetCore.Diagnostics.HealthChecks;

using System.Diagnostics.CodeAnalysis;
using Abstractions;
using Microsoft.Extensions.Diagnostics.HealthChecks;

/// <summary>
/// Represents the default implementation for writing health check responses.
/// This class provides a mechanism to format and output health check results
/// in a predefined manner for consistency and usability in applications.
/// </summary>
[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
[SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes", Justification = "Instantiated via DI")]
internal sealed class DefaultHealthCheckResponseWriter : IHealthCheckResponseWriter
{
    /// <inheritdoc />
    public async Task WriteAsync(HttpContext httpContext, HealthReport healthReport)
    {
        ArgumentNullException.ThrowIfNull(httpContext);
        ArgumentNullException.ThrowIfNull(healthReport);

        await httpContext
            .Response
            .WriteAsJsonAsync(
                new HealthCheck
                {
                    Status = healthReport.Status.ToString(),
                    Duration = healthReport.TotalDuration,
                    Services = healthReport.Entries.ToDictionary(
                        k => k.Key,
                        v => new HealthEntry
                        {
                            Duration = v.Value.Duration,
                            Status = v.Value.Status.ToString(),
                        },
                        StringComparer.Ordinal),
                })
            .ConfigureAwait(false);
    }
}
