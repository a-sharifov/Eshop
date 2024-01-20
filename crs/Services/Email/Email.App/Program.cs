var builder = WebApplication.CreateSlimBuilder(args);

builder.Configuration.AddYamlFile(
    "appsettings.yml", optional: true, reloadOnChange: true);

builder.Services
    .AddOpenTelemetry()
    .WithMetrics(options => options
    .AddPrometheusExporter()
    .AddHttpClientInstrumentation()
    .AddRuntimeInstrumentation());

var app = builder.Build();
