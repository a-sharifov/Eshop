namespace Catalog.Domain.CategoryAggregate;

public sealed class Category : AggregateRoot<CategoryId>
{
    public CategoryName Name { get; private set; }
    public List<Product> Products { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Category() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private Category(CategoryId id, CategoryName name, List<Product> products) : base(id)
    {
        Name = name;
        Products = [];
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
