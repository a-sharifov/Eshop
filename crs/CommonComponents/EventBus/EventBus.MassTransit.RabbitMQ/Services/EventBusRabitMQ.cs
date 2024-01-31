namespace EventBus.MassTransit.RabbitMQ.Services;

public sealed class EventBusRabitMQ(IBusControl busControl) : IEventBus
{
    private readonly IBusControl _busControl = busControl;

    public async Task Publish<TIntegrationEvent>
        (TIntegrationEvent @event, CancellationToken cancellationToken = default)
        where TIntegrationEvent : IIntegrationEvent
    {
        await _busControl.Publish(@event, cancellationToken);
    }
}
