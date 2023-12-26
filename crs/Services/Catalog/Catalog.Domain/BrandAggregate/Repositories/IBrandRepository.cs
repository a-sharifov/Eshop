using Catalog.Domain.BrandAggregate;
using Catalog.Domain.BrandAggregate.Ids;
using Catalog.Domain.BrandAggregate.ValueObjects;
using Catalog.Domain.Common.Repositories;

namespace Catalog.Domain.BrandAggregate.Repositories;

/// <summary>
/// Interface for accessing and manipulating brand entities in the repository.
/// </summary>
public interface IBrandRepository : ICatalogRepository<Brand, BrandId>
{
    /// <summary>
    /// Asynchronously retrieves a brand by its name.
    /// </summary>
    /// <param name="name">The name of the brand to retrieve.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation.
    /// The task result contains the retrieved brand, or null if not found.</returns>
    public Task<Brand?> GetBrandByNameAsync(BrandName name, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously determines whether a brand name is unique.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>A task representing the asynchronous operation. 
    /// The task result contains true if the brand name is unique, otherwise false.</returns>
    public Task<bool> IsBrandNameUniqueAsync(BrandName name, CancellationToken cancellationToken = default);
}
