namespace Catalog.Domain.ProductAggregate.Ids;

public sealed record ProductId(Guid Value) : IStrongestId;
