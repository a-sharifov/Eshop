namespace Catalog.Domain.AggregatesModel.CategoryAggregate.Ids;

public sealed record CategoryId(Guid Value) : IStrongestId;
