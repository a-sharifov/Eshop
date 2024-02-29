namespace Basket.Domain.CatalogBasketAggregate.Ids;

public sealed record ProductId(Guid Value) : IStrongestId;
