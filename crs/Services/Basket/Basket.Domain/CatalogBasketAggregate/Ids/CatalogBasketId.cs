namespace Basket.Domain.CatalogBasketAggregate.Ids;

public sealed record CatalogBasketId(Guid Value) : IStrongestId;
