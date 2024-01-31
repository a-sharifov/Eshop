using EventBus.MassTransit.RabbitMQ.Options;
using MassTransit;

namespace Identity.App.Configurations;

internal sealed class EventBusServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(configure =>
        {
            configure.AddConsumers(App.AssemblyReference.Assembly);
            configure.UsingRabbitMq((context, configurator) =>
            {
                var options = configuration.GetSection(nameof(RabitMQOptions)).Get<RabitMQOptions>();
                configurator.Host(options.Host, options.Port, options.VirtualHost, hostConfigurator =>
                {
                    hostConfigurator.Username(options.Username);
                    hostConfigurator.Password(options.Password);
                });
                configurator.ConfigureEndpoints(context);
            });
        });

    }
}
