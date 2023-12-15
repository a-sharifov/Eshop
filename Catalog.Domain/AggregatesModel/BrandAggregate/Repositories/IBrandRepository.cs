namespace Catalog.Domain.AggregatesModel.BrandAggregate.Repositories;

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
    /// <returns>A task representing the asynchronous operation. The task result contains the retrieved brand, or null if not found.</returns>
    Task<Brand?> GetBrandByNameAsync(BrandName name, CancellationToken cancellationToken = default);
}
