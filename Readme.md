# Aspire.HealthChecks.Kubernetes

Aspire.HealthChecks.Kubernetes provides extension methods to easily add Kubernetes-related health checks to your ASP.NET Core applications and the Aspire Dashboard.
These health checks help monitor the health of your application in a Kubernetes environment by checking the status of the Kubernetes API, nodes, and pods.
You can use it with, or without the Aspire integration.

## About Kubernetes Health Checks
Kubernetes health checks are essential for ensuring that your application is running smoothly within a Kubernetes cluster.
They allow you to monitor the health of the Kubernetes API, nodes, and pods, providing insights into the operational status of your application.
These checks can be integrated into your ASP.NET Core application to provide a robust health monitoring solution.
The 3 health checks used by Kubernetes are:
- Startup: Checks if the application has started successfully.
- Live: Checks if the application is still running and responsive.
- Ready: Checks if the application is ready to handle requests.

## Features
- Simple extension method to register all Kubernetes health checks
- Designed for .NET 9 and ASP.NET Core applications
- Easily extensible for custom health checks

## Getting Started

### Installation
Add a reference to the `Aspire.HealthChecks.Kubernetes` project or package in your ASP.NET Core application.
```powershell
dotnet add package HealthChecks.Kubernetes.Aspire
```

If you are using the Aspire Dashboard, add a reference to the `Aspire.Hosting.HealthChecks.Kubernetes` project in your Aspire AppHost project.
```powershell
dotnet add package HealthChecks.Kubernetes.Aspire.Hosting
```

### Usage

#### Asp.Net Core Application

This will add the 3 health checks to your application.
You can then easily use them in your kubernetes pod yaml file to configure the health checks for your application.
That way Kubernetes can monitor the health of your application and restart it if necessary.

In your `Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Register The general Health Check service
var healthChecksBuilder = builder.Services.AddHealthChecks();

// Add your Health Checks with the Tags from Aspire.HealthChecks.Kubernetes.Common.Constants
healthChecksBuilder.Services.Configure<HealthCheckServiceOptions>(o =>
{
	o.Registrations.Add(new HealthCheckRegistration("My Health Check", new MyHealthCheck(), null, [Constants.LiveTag]));
});

var app = builder.Build();

// Register Kubernetes health checks
app.UseKubernetesHealthChecks();

await app.RunAsync();
```
#### Aspire AppHost

If you are using the Aspire Dashboard, you can easily add the Kubernetes health probes to your Aspire AppHost project.
This will automatically register the health checks with the Aspire Dashboard, allowing you to monitor the health of your application from the dashboard.

In your `Program.cs`:

```csharp
var builder = DistributedApplication.CreateBuilder(args);

/// Add your application
builder.AddProject<MyApp>(nameof(MyApp))
	.WithKubernetesHealthProbes();

var app = builder.Build();

await app.RunAsync();
```

If you are dealing with `ExternalServiceResource`, or do not want probes, you can use `WithKubernetesHealthChecks()` instead.

In your `Program.cs`:

```csharp
var builder = DistributedApplication.CreateBuilder(args);

/// Add your application
builder.AddExternalService("MyExternalService", "https://example.com")
	.WithKubernetesHealthChecks();

var app = builder.Build();

await app.RunAsync();
```
## License
This project is licensed under the Unlicense.
