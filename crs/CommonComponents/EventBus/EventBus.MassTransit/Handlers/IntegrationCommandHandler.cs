namespace EventBus.MassTransit.Handlers;

public abstract class IntegrationCommandHandler<TIntegrationCommand> :
    MessageHandler<TIntegrationCommand> 
    where TIntegrationCommand : class, IIntegrationCommand
{
}
