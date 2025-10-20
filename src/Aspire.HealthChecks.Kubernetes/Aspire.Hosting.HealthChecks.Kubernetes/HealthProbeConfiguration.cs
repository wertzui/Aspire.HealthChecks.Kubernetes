using Aspire.HealthChecks.Kubernetes.Common;

namespace Aspire.Hosting;

/// <summary>
/// Represents the configuration settings for an HTTP health probe used to monitor the health of a service or endpoint.
/// </summary>
public record HealthProbeConfiguration
{
    /// <summary>
    /// Provides default health probe configurations for common application endpoints.
    /// </summary>
    public static class Defaults
    {
        /// <summary>
        /// The default configuration for the startup health probe.
        /// </summary>
        public static HealthProbeConfiguration Startup => new() { Path = Constants.StartupPath };
        /// <summary>
        /// The default configuration for the liveness health probe.
        /// </summary>
        public static HealthProbeConfiguration Liveness => new() { Path = Constants.LivePath };
        /// <summary>
        /// The default configuration for the readiness health probe.
        /// </summary>
        public static HealthProbeConfiguration Readiness => new() { Path = Constants.ReadyPath };
    }

    /// <summary>
    /// The path to be used.
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// The initial delay before calling the probe endpoint for the first time.
    /// </summary>
    public int? InitialDelaySeconds { get; set; }

    /// <summary>
    /// The period between each probe.
    /// </summary>
    public int? PeriodSeconds { get; set; }

    /// <summary>
    /// Number of seconds after which the probe times out.
    /// </summary>
    public int? TimeoutSeconds { get; set; }

    /// <summary>
    /// Number of failures in a row before considers that the overall check has failed.
    /// </summary>
    public int? FailureThreshold { get; set; }

    /// <summary>
    /// Minimum consecutive successes for the probe to be considered successful after having failed.
    /// </summary>
    public int? SuccessThreshold { get; set; }

    /// <summary>
    /// The name of the endpoint to be used for the probe.
    /// </summary>
    public string? EndpointName { get; set; }

}
