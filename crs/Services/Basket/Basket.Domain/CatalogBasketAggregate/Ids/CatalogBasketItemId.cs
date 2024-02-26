namespace Basket.Domain.CatalogBasketAggregate.Ids;

public sealed record CatalogBasketItemId(Guid Value) : IStrongestId;