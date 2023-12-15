namespace Catalog.App.Configurations;

internal sealed class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    { 
        services.AddMediatR(configuration => configuration
        .RegisterServicesFromAssembly(Application.AssemblyReference.Assembly)
        .AddBehavior(typeof(ValidationPipelineBehavior<,>))
        .AddOpenBehavior(typeof(LoggingPipelineBehavior<,>))
        );

        services.Decorate(typeof(INotificationHandler<>), typeof(IdempotentDomainEventHandler<>));

        services.AddValidatorsFromAssembly(
            Application.AssemblyReference.Assembly,
            includeInternalTypes: true);
    }
}