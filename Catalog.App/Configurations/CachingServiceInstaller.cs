namespace Catalog.App.Configurations;

internal sealed class CachingServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(redisOptions =>
        {
            redisOptions.Configuration = configuration.GetConnectionString("RedisConnection") ?? 
            Environment.GetEnvironmentVariable("Redis__ConnectionString");
        });

        var connectionString = configuration.GetConnectionString("RedisConnection") ?? 
            Environment.GetEnvironmentVariable("Redis__ConnectionString");
    }
}
