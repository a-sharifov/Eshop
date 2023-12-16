namespace Catalog.Domain.AggregatesModel.CategoryAggregate;

public sealed class Category : AggregateRoot<CategoryId>
{
    public CategoryName Name { get; private set; }
    public List<Product> Products { get; private set; }

    private Category()
    {
    }

    public Category(CategoryId id, CategoryName name, List<Product> products) : base(id)
    {
        Name = name;
        Products = new();

        AddDomainEvent(
            new CategoryCreatedDomainEvent(Guid.NewGuid(), id));
    }
}
