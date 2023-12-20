namespace Catalog.Application.Services.Brands.Queries.GetBrandById;

internal sealed class GetBrandByIdQueryHandler(IBrandRepository brandRepository) : IQueryHandler<GetBrandByIdQuery, Brand>
{
    private readonly IBrandRepository _brandRepository = brandRepository;

    public async Task<Result<Brand>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var brandId = new BrandId(request.Id);

        return await _brandRepository.GetByIdAsync(brandId) ??
            Result.Failure<Brand>(
                new Error("GetBrandByIdQueryHandler.Handle", 
                $"Brand with such id - {brandId.Value} not found."));
    }
}
