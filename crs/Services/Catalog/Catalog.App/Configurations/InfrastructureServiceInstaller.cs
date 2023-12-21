namespace Catalog.App.Configurations;

internal sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration[SD.DbConfigurationKey];

        services.AddDbContext<CatalogDbContext>(options =>
        options.UseSqlServer(connectionString));

        services.Scan(selector =>
        selector.FromAssemblies(
            Infrastructure.AssemblyReference.Assembly,
            Persistence.AssemblyReference.Assembly)
        .AddClasses(false)
        .AsImplementedInterfaces()
        .WithScopedLifetime());
    }
}
