﻿namespace Catalog.Application.Brands.Commands.CreateBrand;

internal sealed class CreateBrandCommandHandler(
    IBrandRepository brandRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateBrandCommand>
{
    private readonly IBrandRepository _brandRepository = brandRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var brandNameResult = BrandName.Create(request.Name);
        var brandDescriptionResult = BrandDescription.Create(request.Description);
        var brandId = new BrandId(Guid.NewGuid());
        var isBrandNameUnique = await _brandRepository
            .IsBrandNameUniqueAsync(brandNameResult.Value, cancellationToken);

        var brand = Brand.Create(
            brandId,
            brandNameResult.Value,
            brandDescriptionResult.Value,
            products: [],
            isBrandNameUnique
            );

        if (brand.IsFailure)
        {
            return Result.Failure(brand.Error);
        }

        await _brandRepository.AddAsync(brand.Value, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}
