// Licensed to the Escendit GmbH under one or more agreements.
// The Escendit GmbH licenses this file to you under the Apache License 2.0.

namespace Escendit.AspNetCore.Diagnostics.HealthChecks.Abstractions;

/// <summary>
/// Represents a health check result containing overall system health information.
/// </summary>
/// <remarks>
/// This record encapsulates the aggregated health status of an application, along with
/// the duration of the health check process and details about individual services or components.
/// </remarks>
public record HealthCheck
{
    /// <summary>
    /// Gets represents the aggregated health status of the system.
    /// </summary>
    /// <remarks>
    /// This property indicates the overall health status of the application after
    /// performing a health check. It provides a high-level understanding of whether
    /// the system is healthy, degraded, or unhealthy.
    /// </remarks>
    /// <value>
    /// Represents the aggregated health status of the system.
    /// </value>
    public string? Status { get; init; }

    /// <summary>
    /// Gets represents the duration of the health check process.
    /// </summary>
    /// <remarks>
    /// This property specifies the total time taken to execute the health check,
    /// providing insight into the performance and responsiveness of the health check operation.
    /// </remarks>
    /// <value>
    /// Represents the duration of the health check process.
    /// </value>
    public TimeSpan? Duration { get; init; }

    /// <summary>
    /// Gets represents a collection of health check results for individual services or components.
    /// </summary>
    /// <remarks>
    /// This property contains a mapping of service or component names to their respective health entries.
    /// Each entry provides detailed information about the health status and duration of the health check
    /// for the corresponding service or component.
    /// </remarks>
    /// <value>
    /// Represents a collection of health check results for individual services or components.
    /// </value>
    public IDictionary<string, HealthEntry> Services { get; init; } = new Dictionary<string, HealthEntry>(StringComparer.Ordinal);
}
