namespace Basket.Domain.CatalogBasketAggregate.DomainEvents;

public sealed record CatalogBasketCreatedDomainEvent(Guid Id, CatalogBasketId BasketId) : IDomainEvent;
