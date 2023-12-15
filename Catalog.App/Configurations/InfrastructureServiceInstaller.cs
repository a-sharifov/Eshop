namespace Catalog.App.Configurations;

internal sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
            Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

        services.AddDbContext<CatalogDbContext>(options =>
        options.UseSqlServer(connectionString));

        services.Scan(selector =>
        selector.FromAssemblies(
            Infrastructure.AssemblyReference.Assembly,
            Persistence.AssemblyReference.Assembly)
        .AddClasses(false)
        .AsImplementedInterfaces()
        .WithScopedLifetime());

        //alternative variant to migrate db
        //install package FluentMigrator.Runner
        //services.AddFluentMigratorCore()
        // .ConfigureRunner(configure =>
        // configure
        // .AddSqlServer2016()
        // .WithGlobalConnectionString(connectionString)
        // .ScanIn(Persistence.AssemblyReference.Assembly)
        // .For.Migrations())
        // .AddLogging(configure => 
        // configure.AddFluentMigratorConsole());
    }
}
