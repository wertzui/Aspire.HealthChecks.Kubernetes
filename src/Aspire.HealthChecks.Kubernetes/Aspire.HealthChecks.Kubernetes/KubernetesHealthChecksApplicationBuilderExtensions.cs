using Aspire.HealthChecks.Kubernetes.Common;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// Provides extension methods for adding Kubernetes health checks to the application builder.
/// </summary>
public static class KubernetesHealthChecksApplicationBuilderExtensions
{
    /// <summary>
    /// Adds the 3 Kubernetes health checks to the application pipeline.
    /// The checks are:
    /// - Startup: Checks if the application is starting up correctly.
    /// - Live: Checks if the application is live and accepting requests.
    /// - Ready: Checks if the application is ready to serve traffic.
    /// Add the Tags "startup", "live", and "ready" to the respective health checks in your application in order to have your application respond to these health checks.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
    /// <param name="configureOptions">An optional method to further configure the options.</param>
    /// <returns>A reference to the app after the operation has completed.</returns>
    public static IApplicationBuilder UseKubernetesHealthChecks(this IApplicationBuilder app, Action<HealthCheckOptions>? configureOptions = null)
    {
        var startupOptions = new HealthCheckOptions { Predicate = r => r.Tags.Contains(Constants.StartupTag) };
        var liveOptions = new HealthCheckOptions { Predicate = r => r.Tags.Contains(Constants.LiveTag) };
        var readyOptions = new HealthCheckOptions { Predicate = r => r.Tags.Contains(Constants.ReadyTag) };

        configureOptions?.Invoke(startupOptions);
        configureOptions?.Invoke(liveOptions);
        configureOptions?.Invoke(readyOptions);

        app.UseHealthChecks(Constants.StartupPath, startupOptions);
        app.UseHealthChecks(Constants.LivePath, liveOptions);
        app.UseHealthChecks(Constants.ReadyPath, readyOptions);

        return app;
    }
}
