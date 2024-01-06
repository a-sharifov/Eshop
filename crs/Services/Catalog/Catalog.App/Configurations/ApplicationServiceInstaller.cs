namespace Catalog.App.Configurations;

internal sealed class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    { 
        services.AddMediatR(configuration => configuration
        .RegisterServicesFromAssembly(Application.AssemblyReference.Assembly)
        .AddOpenBehavior(typeof(LoggingPipelineBehavior<,>))
        .AddOpenBehavior(typeof(ValidationPipelineBehavior<,>))
        );

        services.Decorate(typeof(INotificationHandler<>), typeof(IdempotentDomainEventHandler<>));

        services.AddValidatorsFromAssembly(
            Application.AssemblyReference.Assembly,
            includeInternalTypes: true);

    }
}
