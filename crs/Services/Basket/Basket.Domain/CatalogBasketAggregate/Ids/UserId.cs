namespace Basket.Domain.CatalogBasketAggregate.Ids;

public sealed record UserId(Guid Value) : IStrongestId;
