namespace EventBus.MassTransit;

public abstract class Consumer<TEvent> : IConsumer<TEvent>
    where TEvent : class, IEvent
{
    public abstract Task Consume(ConsumeContext<TEvent> context);
}
