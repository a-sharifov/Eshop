namespace Catalog.App.Configurations;

internal sealed class CachingServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration) => 
        services.AddStackExchangeRedisCache(redisOptions =>
        redisOptions.Configuration = Env.ConnectionStrings.REDIS);
}
