namespace Catalog.Domain.AggregatesModel.CategoryAggregate.DomainEvents;

public record CategoryCreatedDomainEvent(Guid Id, CategoryId CategoryId) : DomainEvent(Id);