namespace Catalog.Domain.BrandAggregate.DomainEvents;

/// <summary>
/// Represents a domain event that is triggered when a new brand is created.
/// </summary>
/// <param name="Id">The unique identifier of the domain event.</param>
/// <param name="BrandId">The identifier of the newly created brand.</param>
public sealed record BrandCreatedDomainEvent(
    Guid Id,
    BrandId BrandId)
    : DomainEvent(Id);
