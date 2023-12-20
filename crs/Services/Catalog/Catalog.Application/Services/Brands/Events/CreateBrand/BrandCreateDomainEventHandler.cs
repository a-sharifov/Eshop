namespace Catalog.Application.Services.Brands.Events.CreateBrand;

internal sealed class BrandCreateDomainEventHandler(
    IBrandRepository brandRepository) 
    : IDomainEventHandler<BrandCreatedDomainEvent>
{
    private readonly IBrandRepository _brandRepository = brandRepository;

    public async Task Handle(BrandCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        //add logic... 
    }
}
