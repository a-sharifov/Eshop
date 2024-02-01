﻿namespace Identity.App.Configurations;

internal sealed class EventBusServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(configure =>
        {
            configure.AddConsumers(App.AssemblyReference.Assembly);

            configure.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host("rabbitmq", "/",  hostConfigurator =>
                {
                    hostConfigurator.Username(Env.RABBITMQ_DEFAULT_USER);
                    hostConfigurator.Password(Env.RABBITMQ_DEFAULT_PASS);
                });

                configurator.ConfigureEndpoints(context);
            });
        });

    }
}