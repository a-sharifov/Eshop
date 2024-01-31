namespace EventBus.Common.Abstractions;

public interface IIntegrationEventHandler<in TIntegrationEvent> 
    where TIntegrationEvent : IIntegrationEvent
{
    Task Handle(TIntegrationEvent @event);
}
