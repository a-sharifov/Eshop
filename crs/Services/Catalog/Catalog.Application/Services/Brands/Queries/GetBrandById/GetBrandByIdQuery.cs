namespace Catalog.Application.Services.Brands.Queries.GetBrandById;

public sealed record GetBrandByIdQuery(BrandId Id) : IQuery<Brand>;
