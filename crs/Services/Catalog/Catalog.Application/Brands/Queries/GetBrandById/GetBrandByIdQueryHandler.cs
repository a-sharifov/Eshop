namespace Catalog.Application.Brands.Queries.GetBrandById;

internal sealed class GetBrandByIdQueryHandler(IBrandRepository brandRepository) : IQueryHandler<GetBrandByIdQuery, Brand>
{
    private readonly IBrandRepository _brandRepository = brandRepository;

    public async Task<Result<Brand>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var brandId = new BrandId(request.Id);

        var brand = await _brandRepository.GetByIdAsync(brandId);

        return brand ?? Result.Failure<Brand>(
            BrandErrors.BrandNotFound);
    }
}
