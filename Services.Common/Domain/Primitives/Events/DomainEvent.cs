namespace Services.Common.Domain.Primitives.Events;

public abstract record DomainEvent(Guid Id) : IDomainEvent;
