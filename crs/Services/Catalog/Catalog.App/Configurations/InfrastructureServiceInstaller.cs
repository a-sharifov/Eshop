namespace Catalog.App.Configurations;

internal sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            $"Server=mssql,1433;" +
            $"Initial Catalog={SD.MSSQL_INITIAL_CATALOG};" +
            $"User ID={SD.MSSQL_USER_ID};" +
            $"Password={SD.MSSQL_SA_PASSWORD};" +
            $"TrustServerCertificate=true";

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
        .AsImplementedInterfaces()
        .WithScopedLifetime());
    }
}
