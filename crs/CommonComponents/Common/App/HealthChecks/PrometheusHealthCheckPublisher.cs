using Microsoft.Extensions.Diagnostics.HealthChecks;
using Prometheus;

namespace Common.App.HealthChecks;

/// <summary>
/// Publishes ASP.NET Core Health Check statuses as Prometheus metrics.
/// </summary>
internal sealed class PrometheusHealthCheckPublisher(PrometheusHealthCheckPublisherOptions? options) : IHealthCheckPublisher
{
    private readonly Gauge _checkStatus = options?.Gauge 
        ?? new PrometheusHealthCheckPublisherOptions().GetDefaultGauge();

    public Task PublishAsync(HealthReport report, CancellationToken cancellationToken)
    {
        foreach (var reportEntry in report.Entries)
            _checkStatus.WithLabels(reportEntry.Key).Set(HealthStatusToMetricValue(reportEntry.Value.Status));
        return Task.CompletedTask;
    }

    private static double HealthStatusToMetricValue(HealthStatus status) =>
        status switch
        {
            HealthStatus.Unhealthy => 0,
            HealthStatus.Degraded => 0.5,
            HealthStatus.Healthy => 1,
            _ => throw new NotSupportedException($"Unexpected HealthStatus value: {status}"),
        };
}
