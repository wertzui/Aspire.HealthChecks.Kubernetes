using Aspire.HealthChecks.Kubernetes.Common;
using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for adding Kubernetes health checks to resources.
/// </summary>
public static class KubernetesHealthChecksResourceBuilderExtensions
{
    /// <summary>
    /// Adds Kubernetes health checks to the resource.
    /// The checks are:
    /// - Startup: Checks if the application is starting up correctly.
    /// - Live: Checks if the application is live and accepting requests.
    /// - Ready: Checks if the application is ready to serve traffic.
    /// </summary>
    public static IResourceBuilder<T> WithKubernetesHealthChecks<T>(this IResourceBuilder<T> builder, string startupPath = Constants.StartupPath, string livePath = Constants.LivePath, string readyPath = Constants.ReadyPath) where T : IResourceWithEndpoints
    {
        builder.WithHttpHealthCheck(startupPath);
        builder.WithHttpHealthCheck(livePath);
        builder.WithHttpHealthCheck(readyPath);

        return builder;
    }
    /// <summary>
    /// Adds Kubernetes health checks to the resource.
    /// The checks are:
    /// - Startup: Checks if the application is starting up correctly.
    /// - Live: Checks if the application is live and accepting requests.
    /// - Ready: Checks if the application is ready to serve traffic.
    /// </summary>
    public static IResourceBuilder<ExternalServiceResource> WithKubernetesHealthChecks(this IResourceBuilder<ExternalServiceResource> builder, string startupPath = Constants.StartupPath, string livePath = Constants.LivePath, string readyPath = Constants.ReadyPath)
    {
        builder.WithHttpHealthCheck(startupPath);
        builder.WithHttpHealthCheck(livePath);
        builder.WithHttpHealthCheck(readyPath);

        return builder;
    }
}
