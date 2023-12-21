namespace Identity.App.Configurations;

internal sealed class InfrasctructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration[SD.DbConfigurationKey];

        services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.Scan(selector =>
        selector.FromAssemblies(
            Infrastructure.AssemblyReference.Assembly,
            Persistence.AssemblyReference.Assembly)
        .AddClasses(false)
        .AsImplementedInterfaces()
        .WithScopedLifetime());
    }
}
