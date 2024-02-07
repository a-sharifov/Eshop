namespace Email.App.Configurations;

internal sealed class MessageBusServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(configure =>
        {
            configure.SetKebabCaseEndpointNameFormatter();
            configure.AddConsumers(MessageBus.AssemblyReference.Assembly);
            configure.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host("rabbitmq", "/", hostConfigurator =>
                {
                    hostConfigurator.Username(Env.RABBITMQ_DEFAULT_USER);
                    hostConfigurator.Password(Env.RABBITMQ_DEFAULT_PASS);
                });

                configurator.ConfigureEndpoints(context);
            });

            configure.AddConsumers(App.AssemblyReference.Assembly);
        });
    }
}
