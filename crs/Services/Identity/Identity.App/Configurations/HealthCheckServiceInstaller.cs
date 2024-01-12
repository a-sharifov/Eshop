namespace Identity.App.Configurations;

internal sealed class HealthCheckServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
           $"Server=postgres;" +
           $"Port=5432;" +
           $"Database={Env.POSTGRES_DB};" +
           $"Username={Env.POSTGRES_USER};" +
           $"Password={Env.POSTGRES_PASSWORD}" +
           $";TimeZone=UTC;";


        services
        .AddHealthChecks()
        .AddNpgSql(
            connectionString: connectionString,
            name: "IdentityDb");
    }
}
