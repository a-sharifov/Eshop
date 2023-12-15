namespace Catalog.App.Configurations;

internal sealed class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    { 
        //разница addopenbehavior от addbehavior в том что addopenbehavior
        //добавляет поведение в цепочку поведений а addbehavior добавляет поведение в конец цепочки поведений
        //а ну еще в инете норм ответа нет так что исправь если что
        services.AddMediatR(configuration => configuration
        .RegisterServicesFromAssembly(Application.AssemblyReference.Assembly)
        .AddOpenBehavior(typeof(ValidationPipelineBehavior<,>))
        .AddOpenBehavior(typeof(LoggingPipelineBehavior<,>))
        );

        services.Decorate(typeof(INotificationHandler<>), typeof(IdempotentDomainEventHandler<>));

        services.AddValidatorsFromAssembly(
            Application.AssemblyReference.Assembly,
            includeInternalTypes: true);
    }
}