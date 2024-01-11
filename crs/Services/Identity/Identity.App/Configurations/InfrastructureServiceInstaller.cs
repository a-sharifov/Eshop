using Identity.Application.Abstractions;

namespace Identity.App.Configurations;

internal sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = 
            $"Server=postgres;" +
            $"Port=5432;" +
            $"Database={Env.POSTGRES_DB};" +
            $"Username={Env.POSTGRES_USER};" +
            $"Password={Env.POSTGRES_PASSWORD}" +
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
