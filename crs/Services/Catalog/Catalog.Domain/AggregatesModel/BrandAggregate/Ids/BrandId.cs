namespace Catalog.Domain.AggregatesModel.BrandAggregate.Ids;

/// <summary>
/// Represents the unique identifier of a brand.
/// </summary>
/// <param name="Value">The unique identifier value.</param>
public sealed record BrandId(Guid Value) : IStrongestId;
