namespace EventBus.MassTransit.Abstractions;

public interface IMessageHandler<TMessage>
     where TMessage : class, IMessage
{
    Task Handle(ConsumeContext<TMessage> context);
}
