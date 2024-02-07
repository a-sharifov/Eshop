namespace Email.App.Configurations;

internal sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.Scan(services => services
        .FromAssemblies(Infrastructure.AssemblyReference.Assembly)
        .AddClasses(false)
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime());

        services.ConfigureOptions<EmailOptionsSetup>();
    }
}
