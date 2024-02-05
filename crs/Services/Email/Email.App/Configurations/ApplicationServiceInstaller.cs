namespace Email.App.Configurations;

internal sealed class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(configuration => configuration
              .RegisterServicesFromAssembly(Application.AssemblyReference.Assembly)
              .AddOpenBehavior(typeof(LoggingPipelineBehavior<,>))
              .AddOpenBehavior(typeof(ValidationPipelineBehavior<,>))
              );

        services.AddValidatorsFromAssembly(
            Application.AssemblyReference.Assembly,
            includeInternalTypes: true); 
    }
}
