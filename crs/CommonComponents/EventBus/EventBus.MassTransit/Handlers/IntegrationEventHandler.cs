namespace EventBus.MassTransit.Handlers;

public abstract class IntegrationEventHandler<TIntegrationEvent> :
    MessageHandler<TIntegrationEvent>
    where TIntegrationEvent : class, IIntegrationEvent
{
}
