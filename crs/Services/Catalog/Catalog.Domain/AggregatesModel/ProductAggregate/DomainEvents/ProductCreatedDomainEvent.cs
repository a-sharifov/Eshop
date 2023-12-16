namespace Catalog.Domain.AggregatesModel.ProductAggregate.DomainEvents;

public record ProductCreatedDomainEvent(Guid Id, ProductId ProductId) : DomainEvent(Id);