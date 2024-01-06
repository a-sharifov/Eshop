namespace Catalog.Domain.CategoryAggregate.Ids;

public sealed record CategoryId(Guid Value) : IStrongestId;
