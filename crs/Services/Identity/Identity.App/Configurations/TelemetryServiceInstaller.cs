namespace Identity.App.Configurations;

internal sealed class TelemetryServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration) =>
        services
        .AddOpenTelemetry()
        .WithMetrics(options =>
        {
            options.AddPrometheusExporter();

            options.AddMeter(
                "Microsoft.AspNetCore.Hosting",
                "Microsoft.AspNetCore.Server.Kestrel");

            options.AddView(
                "request-processing-identity-api",
                new ExplicitBucketHistogramConfiguration()  
                {
                    Boundaries = [10, 20]
                });
        });
}
