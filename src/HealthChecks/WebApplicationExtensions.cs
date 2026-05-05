// Licensed to the Escendit GmbH under one or more agreements.
// The Escendit GmbH licenses this file to you under the Apache License 2.0.

namespace Escendit.AspNetCore.Diagnostics.HealthChecks;

using Abstractions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

/// <summary>
/// Provides extension methods for configuring health checks in a web application.
/// </summary>
public static class WebApplicationExtensions
{
    /// <summary>
    /// Provides extension methods for configuring health check routes with standard defaults in a web application.
    /// </summary>
    extension(WebApplication app)
    {
        /// <summary>
        /// Configures health check routes with standardized defaults in the specified web application.
        /// </summary>
        /// <returns>The configured <see cref="WebApplication"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <see cref="WebApplication"/> instance is null.</exception>
        public WebApplication UseHealthCheckDefaults()
        {
            ArgumentNullException.ThrowIfNull(app);
            var responseWriter = app.Services.GetRequiredService<IHealthCheckResponseWriter>();
            app.MapHealthChecks(DefaultHealthCheckPathPrefix, new HealthCheckOptions
            {
                ResponseWriter = responseWriter.WriteAsync,
            });
            app.MapHealthChecks($"{DefaultHealthCheckPathPrefix}/ready", new HealthCheckOptions
            {
                ResponseWriter = responseWriter.WriteAsync,
                Predicate = healthCheck => healthCheck.Tags.Contains("ready"),
            });
            app.MapHealthChecks($"{DefaultHealthCheckPathPrefix}/live", new HealthCheckOptions
            {
                ResponseWriter = responseWriter.WriteAsync,
                Predicate = healthCheck => healthCheck.Tags.Contains("live"),
            });
            app.MapHealthChecks($"{DefaultHealthCheckPathPrefix}/startup", new HealthCheckOptions
            {
                ResponseWriter = responseWriter.WriteAsync,
                Predicate = healthCheck => healthCheck.Tags.Contains("startup"),
            });
            return app;
        }
    }

    private const string DefaultHealthCheckPathPrefix = "/.well-known/healthz";
}
