namespace Common.Domain.Primitives.Events;

/// <summary>
/// class for domain event.
/// </summary>
/// <param name="Id"> The id of the event.</param>
public abstract record DomainEvent(Guid Id) : IDomainEvent;
