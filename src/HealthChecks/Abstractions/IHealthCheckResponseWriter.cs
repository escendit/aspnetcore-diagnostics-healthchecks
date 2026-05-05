// Licensed to the Escendit GmbH under one or more agreements.
// The Escendit GmbH licenses this file to you under the Apache License 2.0.

namespace Escendit.AspNetCore.Diagnostics.HealthChecks.Abstractions;

using Microsoft.Extensions.Diagnostics.HealthChecks;

/// <summary>
/// Defines a contract for writing a health check response to the HTTP context.
/// </summary>
public interface IHealthCheckResponseWriter
{
    /// <summary>
    /// Writes a health check response to the provided HTTP context asynchronously.
    /// </summary>
    /// <param name="httpContext">The HTTP context to which the health check response should be written.</param>
    /// <param name="healthReport">The health report containing the results of the health checks.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task WriteAsync(HttpContext httpContext, HealthReport healthReport);
}
