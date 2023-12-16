namespace Catalog.Domain.AggregatesModel.SellerAggregate.DomainEvents;

public record SellerCreatedDomainEvent(Guid Id, SellerId SellerId) : DomainEvent(Id);