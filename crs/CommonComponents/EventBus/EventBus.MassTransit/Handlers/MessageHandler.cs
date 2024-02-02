namespace EventBus.MassTransit.Handlers;

public abstract class MessageHandler<TMessage> : 
    IConsumer<TMessage>, IMessageHandler<TMessage>
    where TMessage : class, IMessage
{
    public async Task Consume(ConsumeContext<TMessage> context)
    {
        await Handle(context);
    }

    public abstract Task Handle(ConsumeContext<TMessage> context);
}
