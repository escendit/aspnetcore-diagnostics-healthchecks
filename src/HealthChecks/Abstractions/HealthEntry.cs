// Licensed to the Escendit GmbH under one or more agreements.
// The Escendit GmbH licenses this file to you under the Apache License 2.0.

namespace Escendit.AspNetCore.Diagnostics.HealthChecks.Abstractions;

/// <summary>
/// Represents an entry that provides information about the health status and duration of a specific service or component.
/// </summary>
public record HealthEntry
{
    /// <summary>
    /// Gets the health status of a specific service or component.
    /// </summary>
    /// <remarks>
    /// The status indicates the current operational state of the service or component,
    /// which may be used to assess its health condition.
    /// </remarks>
    /// <value>
    /// The health status of a specific service or component.
    /// </value>
    public string? Status { get; init; }

    /// <summary>
    /// Gets the duration of the health check execution for a specific service or component.
    /// </summary>
    /// <remarks>
    /// The duration indicates the time taken to perform the health check, which can be useful
    /// for identifying performance issues or evaluating responsiveness.
    /// </remarks>
    /// <value>
    /// The duration of the health check execution.
    /// </value>
    public TimeSpan? Duration { get; init; }
}
