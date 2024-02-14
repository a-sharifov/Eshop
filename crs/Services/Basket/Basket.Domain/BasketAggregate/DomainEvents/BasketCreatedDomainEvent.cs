namespace Basket.Domain.BasketAggregate.DomainEvents;

public sealed record BasketCreatedDomainEvent(Guid Id, BasketId BasketId) : IDomainEvent;
