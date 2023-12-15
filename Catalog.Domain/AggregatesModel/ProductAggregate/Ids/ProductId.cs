namespace Catalog.Domain.AggregatesModel.ProductAggregate.Ids;

public sealed record ProductId(Guid Value) : IStrongestId;
