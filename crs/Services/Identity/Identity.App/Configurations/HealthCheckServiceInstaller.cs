namespace Identity.App.Configurations;

internal sealed class HealthCheckServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration) =>
        services
        .AddHealthChecks()
        .AddNpgSql(
            connectionString: Env.ConnectionStrings.POSTGRES,
            name: "IdentityDb")
        .ForwardToPrometheus(new PrometheusHealthCheckPublisherOptions
        {
            Gauge = Metrics.CreateGauge(
                name: "identityapp_aspnetcore_healthcheck_status",
                help: "ASP.NET Core health check status (0 == Unhealthy, 0.5 == Degraded, 1 == Healthy)",
                labelNames: ["name"]
                )
        });
}
