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
    public static IResourceBuilder<T> WithKubernetesHealthChecks<T>(this IResourceBuilder<T> builder, string startupPath = Constants.StartupPath, string livePath = Constants.LivePath, string readyPath = Constants.ReadyPath)
        where T : IResourceWithEndpoints
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

    /// <summary>
    /// Adds Kubernetes health probes to the resource.
    /// The probes are:
    /// - Startup: Checks if the application is starting up correctly.
    /// - Live: Checks if the application is live and accepting requests.
    /// - Ready: Checks if the application is ready to serve traffic.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <param name="startupConfig">The configuration for the startup probe. If none is given, the default <see cref="HealthProbeConfiguration.Defaults.Startup"/>, which configures just the path as <see cref="Constants.StartupPath"/>, will be used</param>
    /// <param name="liveConfig">The configuration for the liveness probe. If none is given, the default <see cref="HealthProbeConfiguration.Defaults.Liveness"/>, which configures just the path as <see cref="Constants.LivePath"/>, will be used</param>
    /// <param name="readyConfig">The configuration for the readiness probe. If none is given, the default <see cref="HealthProbeConfiguration.Defaults.Readiness"/>, which configures just the path as <see cref="Constants.ReadyPath"/>, will be used</param>
#pragma warning disable ASPIREPROBES001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    public static IResourceBuilder<T> WithKubernetesHealthProbes<T>(this IResourceBuilder<T> builder, HealthProbeConfiguration? startupConfig = null, HealthProbeConfiguration? liveConfig = null, HealthProbeConfiguration? readyConfig = null)
        where T : IResourceWithEndpoints, IResourceWithProbes
    {
        startupConfig ??= HealthProbeConfiguration.Defaults.Startup;
        liveConfig ??= HealthProbeConfiguration.Defaults.Liveness;
        readyConfig ??= HealthProbeConfiguration.Defaults.Readiness;

        builder.WithHttpProbe(ProbeType.Startup, startupConfig.Path, startupConfig.InitialDelaySeconds, startupConfig.PeriodSeconds, startupConfig.TimeoutSeconds, startupConfig.FailureThreshold, startupConfig.SuccessThreshold, startupConfig.EndpointName);
        builder.WithHttpProbe(ProbeType.Liveness, liveConfig.Path, liveConfig.InitialDelaySeconds, liveConfig.PeriodSeconds, liveConfig.TimeoutSeconds, liveConfig.FailureThreshold, liveConfig.SuccessThreshold, liveConfig.EndpointName);
        builder.WithHttpProbe(ProbeType.Readiness, readyConfig.Path, readyConfig.InitialDelaySeconds, readyConfig.PeriodSeconds, readyConfig.TimeoutSeconds, readyConfig.FailureThreshold, readyConfig.SuccessThreshold, readyConfig.EndpointName);
#pragma warning restore ASPIREPROBES001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

        return builder;
    }
}
