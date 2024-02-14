namespace Basket.Domain.BasketAggregate.Ids;

public record BasketId(Guid Value) : IStrongestId;
