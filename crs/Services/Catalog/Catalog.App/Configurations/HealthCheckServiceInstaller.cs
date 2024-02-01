namespace Catalog.App.Configurations;

internal sealed class HealthCheckServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration) =>
        services
        .AddHealthChecks()
        .AddSqlServer(
            connectionString: Env.ConnectionStrings.MSSQL,
            name: "CatalogAppDb")
        .AddRedis(
            redisConnectionString: Env.ConnectionStrings.REDIS,
            name: "CatalogCaching")
        .ForwardToPrometheus(new PrometheusHealthCheckPublisherOptions
        {
            Gauge = Metrics.CreateGauge(
                name: "catalogapi_aspnetcore_healthcheck_status",
                help: "ASP.NET Core health check status (0 == Unhealthy, 0.5 == Degraded, 1 == Healthy)",
                labelNames: ["name"]
                )
        });
}
