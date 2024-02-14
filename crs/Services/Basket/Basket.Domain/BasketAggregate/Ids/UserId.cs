namespace Basket.Domain.BasketAggregate.Ids;

public sealed record UserId(Guid Value) : IStrongestId;
