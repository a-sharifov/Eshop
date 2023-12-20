namespace Catalog.App.Configurations;

internal sealed class CachingServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var redisConnectionString = configuration["RedisConnection"];

        services.AddStackExchangeRedisCache(redisOptions =>
        {
            redisOptions.Configuration = redisConnectionString;
        });
    }
}
