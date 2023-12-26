namespace Catalog.Application.Brands.Queries.GetBrandById;

public sealed record GetBrandByIdQuery(Guid Id) : IQuery<Brand>;
