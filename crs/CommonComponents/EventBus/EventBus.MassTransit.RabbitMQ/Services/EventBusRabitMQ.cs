namespace EventBus.MassTransit.RabbitMQ.Services;

public sealed class EventBusRabitMQ(IBusControl busControl) : IEventBus
{
    private readonly IBusControl _busControl = busControl;

    public async Task Publish<TEvent>
        (TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : IEvent
    {
        await _busControl.Publish(@event, cancellationToken);
    }
}
