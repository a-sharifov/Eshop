using Catalog.Domain.CategoryAggregate.Errors;
using Catalog.Domain.CategoryAggregate.Ids;
using Catalog.Domain.CategoryAggregate.ValueObjects;
using Catalog.Domain.ProductAggregate;

namespace Catalog.Domain.CategoryAggregate;

public sealed class Category : AggregateRoot<CategoryId>
{
    public CategoryName Name { get; private set; }
    public List<Product> Products { get; private set; }

    private Category()
    {
    }

    private Category(CategoryId id, CategoryName name, List<Product> products) : base(id)
    {
        Name = name;
        Products = new();
    }

    public static Result<Category> Create(
        CategoryId id,
        CategoryName name,
        List<Product> products,
        bool isCategoryNameUnique)
    {
        if (!isCategoryNameUnique)
        {
            return Result.Failure<Category>(
                CategoryErrors.CategoryNameIsNotUnique);
        }

        var category = new Category(id, name, products);

        category.AddDomainEvent(
            new CategoryCreatedDomainEvent(Guid.NewGuid(), id));

        return category;
    }
}
