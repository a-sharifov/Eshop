namespace Basket.Domain.BasketAggregate.Ids;

public record ProductId(Guid Value) : IStrongestId;