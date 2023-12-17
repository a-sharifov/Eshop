namespace Catalog.Application.Services.Brands.Events.CreateBrand;

internal sealed class BrandCreateDomainEventHandler(
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

        for (int i = 0; i < 1000; i++)
        {
            await Console.Out.WriteLineAsync("Hellooooooo");
        }

    }
}
