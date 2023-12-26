using Catalog.Domain.BrandAggregate.DomainEvents;
using Catalog.Domain.BrandAggregate.Repositories;

namespace Catalog.Application.Brands.Events;

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
