namespace EventBus.Common.Abstractions;

public interface IMessageBusBuilder
{
    IServiceCollection Services { get; }
}
