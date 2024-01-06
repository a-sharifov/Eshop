using Catalog.Domain.ProductAggregate;
using Catalog.Domain.ProductAggregate.Repositories;

namespace Catalog.Application.Products.Queries.GetProductsByFilter;

public sealed class GetProductsByFilterQuerieHandler(IProductRepository productRepository) : IQueryHandler<GetProductsByFilterQuerie, IEnumerable<Product>>
{
    public readonly IProductRepository _productRepository = productRepository;

    public Task<Result<IEnumerable<Product>>> Handle(GetProductsByFilterQuerie request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

    }
}
