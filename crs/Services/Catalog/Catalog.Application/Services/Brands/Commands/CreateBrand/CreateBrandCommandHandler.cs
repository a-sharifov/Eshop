﻿namespace Catalog.Application.Services.Brands.Commands.CreateBrand;

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

        var brand = new Brand(
            brandId,
            brandNameResult.Value,
            brandDescriptionResult.Value,
            products: [],
            isBrandNameUnique
            );

        await _brandRepository.AddAsync(brand, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
