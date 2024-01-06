namespace Identity.App.Configurations;

internal sealed class LoggingServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        //var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        //Log.Logger = new LoggerConfiguration()
        //    .Enrich.FromLogContext()
        //    .WriteTo.Debug()
        //    .WriteTo.Console()
        //    .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
        //    .ReadFrom.Configuration(configuration)
        //    .CreateLogger();
    }
}
