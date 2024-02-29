namespace Basket.Domain.CatalogBasketAggregate.Ids;

public sealed record CatalogProductId(Guid Value) : IStrongestId;
