namespace Catalog.Domain.SellerAggregate.Ids;

public sealed record SellerId(Guid Value) : IStrongestId;
