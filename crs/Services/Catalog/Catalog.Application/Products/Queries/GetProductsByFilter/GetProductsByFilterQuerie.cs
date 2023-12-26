using Catalog.Domain.ProductAggregate;

namespace Catalog.Application.Products.Queries.GetProductsByFilter;

public sealed record GetProductsByFilterQuerie(
    int skip,
    int take,
    string? Sku,
    string? Name,
    decimal? PriceFrom,
    decimal? PriceTo,
    Guid? CategoryId,
    Guid? SellerId,
    Guid? BrandId) : IQuery<IEnumerable<Product>>;
