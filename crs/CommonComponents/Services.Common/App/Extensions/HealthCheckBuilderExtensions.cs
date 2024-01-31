using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Services.Common.App.HealthChecks;

namespace Services.Common.App.Extensions;

// if you need to add more health checks, you can do it here:
// https://github.com/prometheus-net/prometheus-net/blob/master/Prometheus.AspNetCore.HealthChecks/HealthCheckBuilderExtensions.cs
public static class HealthCheckBuilderExtensions
{
    public static IHealthChecksBuilder ForwardToPrometheus(this IHealthChecksBuilder builder, PrometheusHealthCheckPublisherOptions? options = null)
    {
        builder.Services
            .AddSingleton<IHealthCheckPublisher, PrometheusHealthCheckPublisher>(
            provider => new PrometheusHealthCheckPublisher(options));

        return builder;
    }
}
