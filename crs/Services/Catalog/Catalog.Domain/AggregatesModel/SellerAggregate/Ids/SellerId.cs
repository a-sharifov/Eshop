namespace Catalog.Domain.AggregatesModel.SellerAggregate.Ids;

public sealed record SellerId(Guid Value) : IStrongestId;
