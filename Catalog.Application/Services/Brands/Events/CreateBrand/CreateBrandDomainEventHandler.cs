namespace Catalog.Application.Services.Brands.Events.CreateBrand;

internal sealed class CreateBrandDomainEventHandler(
    IBrandRepository brandRepository,
    IUnitOfWork unitOfWork) 
    : IDomainEventHandler<BrandCreatedDomainEvent>
{
    private readonly IBrandRepository _brandRepository = brandRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(BrandCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var brandId = notification.BrandId;

        var brand = await _brandRepository.GetByIdAsync(brandId);

        //add logic...

    }
}
