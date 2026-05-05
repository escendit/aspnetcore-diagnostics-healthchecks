// Licensed to the Escendit GmbH under one or more agreements.
// The Escendit GmbH licenses this file to you under the Apache License 2.0.

namespace Escendit.AspNetCore.Diagnostics.HealthChecks;

using Abstractions;

/// <summary>
/// Provides extension methods for configuring health checks and diagnostics in an ASP.NET Core application
/// during the WebApplicationBuilder setup phase.
/// </summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    /// Provides a collection of extension methods to enhance the functionality of the WebApplicationBuilder
    /// for configuring health check defaults in an ASP.NET Core application setup phase.
    /// </summary>
    extension(WebApplicationBuilder builder)
    {
        /// <summary>
        /// Configures the default health check services in the application builder.
        /// </summary>
        /// <returns>The <see cref="WebApplicationBuilder"/> instance for further configuration.</returns>
        public WebApplicationBuilder AddHealthCheckDefaults(Action<IHealthChecksBuilder>? configure = null)
        {
            ArgumentNullException.ThrowIfNull(builder);

            var healthChecksBuilder = builder
                .Services
                .AddTransient<IHealthCheckResponseWriter, DefaultHealthCheckResponseWriter>()
                .AddHealthChecks()
                .AddCheck<MinimalHealthCheck>("self");

            configure?.Invoke(healthChecksBuilder);
            return builder;
        }
    }
}
