namespace Catalog.App.Configurations;

internal sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Env.ConnectionStrings.MSSQL;

        services.Configure<SqlConnectionFactoryOptions>(options =>
            options.ConnectionString = connectionString
        );

        services.AddDbContext<CatalogDbContext>(options =>
        options.UseSqlServer(connectionString));

        services.Scan(selector =>
        selector.FromAssemblies(
            Infrastructure.AssemblyReference.Assembly,
            Persistence.AssemblyReference.Assembly)
        .AddClasses(false)
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime());
    }
}
