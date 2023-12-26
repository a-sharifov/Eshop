using Catalog.Domain.CategoryAggregate;
using Catalog.Domain.CategoryAggregate.Ids;
using Catalog.Domain.CategoryAggregate.ValueObjects;
using Catalog.Domain.Common.Repositories;

namespace Catalog.Domain.CategoryAggregate.Repositories;

public interface ICategoryRepository : ICatalogRepository<Category, CategoryId>
{
    public Task<Category?> GetCategoryByNameAsync(CategoryName name, CancellationToken cancellationToken = default);
    public Task<bool> IsCategoryNameUniqueAsync(CategoryName name, CancellationToken cancellationToken = default);
}