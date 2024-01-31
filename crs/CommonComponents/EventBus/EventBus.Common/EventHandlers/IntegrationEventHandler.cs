namespace EventBus.Common.EventHandlers;

public abstract record IntegrationEventHandler<TIntegrationEventHandler>
    : IIntegrationEventHandler<TIntegrationEventHandler>,
    IConsumer<TIntegrationEventHandler>
    where TIntegrationEventHandler : class, IIntegrationEvent
{
    public async Task Consume(ConsumeContext<TIntegrationEventHandler> context)
    {
        await Handle(context.Message);
    }

    public abstract Task Handle(TIntegrationEventHandler @event);
}
