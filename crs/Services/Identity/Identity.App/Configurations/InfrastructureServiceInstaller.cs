using Identity.Application.Abstractions;

namespace Identity.App.Configurations;

internal sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = 
            $"Server=postgres;" +
            $"Port=5432;" +
            $"Database={SD.POSTGRES_DB};" +
            $"Username={SD.POSTGRES_USER};" +
            $"Password={SD.POSTGRES_PASSWORD}" +
            $";TimeZone=UTC;";

        services.AddDbContext<UserDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddTransient<IIdentityEmailService, IdentityEmailService>();

        services.Scan(selector =>
        selector.FromAssemblies(
            Infrastructure.AssemblyReference.Assembly,
            Persistence.AssemblyReference.Assembly)
        .AddClasses(false)
        .AsImplementedInterfaces()
        .WithScopedLifetime());

        services.ConfigureOptions<EmailOptionsSetup>();
    }
}
