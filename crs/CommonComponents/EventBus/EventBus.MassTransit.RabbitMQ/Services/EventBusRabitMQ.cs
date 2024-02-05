namespace EventBus.MassTransit.RabbitMQ.Services;

public sealed class EventBusRabitMQ(IBusControl busControl) : IMessageBus
{
    private readonly IBusControl _busControl = busControl;

    public async Task Publish<TEvent>
        (TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : IIntegrationEvent
    {
        await _busControl.Publish(@event, cancellationToken);
    }

    public async Task Send<TCommand>
        (TCommand command, CancellationToken cancellationToken = default)
        where TCommand : IIntegrationCommand
    {
        await _busControl.Send(command, cancellationToken);
    }
}
