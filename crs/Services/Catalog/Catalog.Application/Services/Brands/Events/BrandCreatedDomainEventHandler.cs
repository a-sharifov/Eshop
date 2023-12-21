namespace Catalog.Application.Services.Brands.Events;

internal sealed class BrandCreatedDomainEventHandler(
    IBrandRepository brandRepository)
    : IDomainEventHandler<BrandCreatedDomainEvent>
{
    private readonly IBrandRepository _brandRepository = brandRepository;

    public async Task Handle(BrandCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        //add logic... 
    }
}
