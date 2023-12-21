namespace Catalog.Domain.AggregatesModel.SellerAggregate.DomainEvents;

public sealed record SellerCreatedDomainEvent(
    Guid Id, 
    SellerId SellerId) 
    : DomainEvent(Id);
