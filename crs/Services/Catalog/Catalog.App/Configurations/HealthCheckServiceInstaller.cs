namespace Catalog.App.Configurations;

internal sealed class HealthCheckServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
           $"Server=mssql,1433;" +
           $"Initial Catalog={Env.MSSQL_INITIAL_CATALOG};" +
           $"User ID={Env.MSSQL_USER_ID};" +
           $"Password={Env.MSSQL_SA_PASSWORD};" +
           $"TrustServerCertificate=true";

        var redisConnectionString = $"redis:6379,password={Env.REDIS_PASSWORD}";

        services
        .AddHealthChecks()
        .AddSqlServer(
            connectionString: connectionString,
            name: "CatalogAppDb")
        .AddRedis(
            redisConnectionString: redisConnectionString,
            name: "CatalogCaching");
    }
}
