namespace Aspire.HealthChecks.Kubernetes.Common;

/// <summary>
/// Provides constant values used for health check tags and paths in the application.
/// </summary>
/// <remarks>This class contains predefined string constants for health check tags and their corresponding
/// endpoint paths. These constants can be used to standardize health check implementations across the
/// application.</remarks>
public static class Constants
{
    /// <summary>
    /// The tag used for the startup health check.
    /// Use this tag to identify the health check that verifies if the application is starting up correctly.
    /// </summary>
    public const string StartupTag = "startup";

    /// <summary>
    /// The tag used for the live health check.
    /// Use this tag to identify the health check that verifies if the application is live and accepting requests.
    /// </summary>
    public const string LiveTag = "live";

    /// <summary>
    /// The tag used for the ready health check.
    /// Use this tag to identify the health check that verifies if the application is ready to serve traffic.
    /// </summary>
    public const string ReadyTag = "ready";

    /// <summary>
    /// The path used for the startup health check.
    /// All health checks with the <see cref="StartupTag"/> will respond to this path.
    /// </summary>
    public const string StartupPath = "/health/startup";

    /// <summary>
    /// The path used for the live health check.
    /// All health checks with the <see cref="LiveTag"/> will respond to this path.
    /// </summary>
    public const string LivePath = "/health/live";

    /// <summary>
    /// The path used for the ready health check.
    /// All health checks with the <see cref="ReadyTag"/> will respond to this path.
    /// </summary>
    public const string ReadyPath = "/health/ready";
}