using Catalog.Domain.ProductAggregate.Ids;

namespace Catalog.Domain.ProductAggregate.DomainEvents;

public sealed record ProductCreatedDomainEvent(
    Guid Id,
    ProductId ProductId)
    : DomainEvent(Id);
