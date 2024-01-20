namespace Catalog.App.Configurations;

internal sealed class TelemetryServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration) =>
        services
        .AddOpenTelemetry()
        .WithMetrics(options =>
        options
        .AddPrometheusExporter()
        .AddHttpClientInstrumentation()
        .AddRuntimeInstrumentation());
}
