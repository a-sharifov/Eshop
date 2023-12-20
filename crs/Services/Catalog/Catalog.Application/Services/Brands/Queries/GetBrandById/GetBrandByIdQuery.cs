namespace Catalog.Application.Services.Brands.Queries.GetBrandById;

public sealed record GetBrandByIdQuery(Guid Id) : IQuery<Brand>;
