using Catalog.Domain.SellerAggregate.Ids;

namespace Catalog.Domain.SellerAggregate.DomainEvents;

public sealed record SellerCreatedDomainEvent(
    Guid Id,
    SellerId SellerId)
    : DomainEvent(Id);
