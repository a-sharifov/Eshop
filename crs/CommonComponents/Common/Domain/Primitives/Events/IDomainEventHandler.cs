namespace Common.Domain.Primitives.Events;

/// <summary>
/// Interface for domain event handler.
/// </summary>
/// <typeparam name="TDomainEvent"> The domain event type.</typeparam>
public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
where TDomainEvent : IDomainEvent
{
}
