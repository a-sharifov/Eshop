namespace Catalog.Domain.AggregatesModel.ProductAggregate.DomainEvents;

public sealed record ProductCreatedDomainEvent(
    Guid Id, 
    ProductId ProductId) 
    : DomainEvent(Id);
