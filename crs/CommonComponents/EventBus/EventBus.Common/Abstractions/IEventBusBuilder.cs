namespace EventBus.Common.Abstractions;

public interface IEventBusBuilder
{
    IServiceCollection Services { get; }
}
