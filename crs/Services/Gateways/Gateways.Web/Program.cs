using OpenTelemetry.Metrics;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddYamlFile(
    "appsettings.yml", optional: true, reloadOnChange: true);

builder.Services
    .AddOpenTelemetry()
    .WithMetrics(options => options
    .AddPrometheusExporter()
    .AddHttpClientInstrumentation()
    .AddRuntimeInstrumentation());

builder.Services.AddLettuceEncrypt();
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapReverseProxy();

app.Run();