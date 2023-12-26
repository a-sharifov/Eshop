namespace Catalog.Domain.CategoryAggregate.DomainEvents;

public sealed record CategoryCreatedDomainEvent(
    Guid Id,
    CategoryId CategoryId)
    : DomainEvent(Id);