using Catalog.Domain.BrandAggregate.Errors;
using Catalog.Domain.BrandAggregate.Ids;
using Catalog.Domain.BrandAggregate.ValueObjects;
using Catalog.Domain.ProductAggregate;

namespace Catalog.Domain.BrandAggregate;

/// <summary>
/// Represents a brand within the catalog as an aggregate root.
/// </summary>
public sealed class Brand : AggregateRoot<BrandId>
{
    /// <summary>
    /// Gets the name of the brand.
    /// </summary>
    public BrandName Name { get; private set; }

    /// <summary>
    /// Gets the description of the brand.
    /// </summary>
    public BrandDescription Description { get; private set; }

    /// <summary>
    /// Gets the list of products associated with the brand.
    /// </summary>
    public List<Product> Products { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Brand"/> class.
    /// </summary>
    private Brand()
    {
        // Required for Entity Framework Core
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Brand"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the brand.</param>
    /// <param name="name">The name of the brand.</param>
    /// <param name="description">The description of the brand.</param>
    /// <param name="products">The list of products associated with the brand.</param>
    private Brand(
        BrandId id,
        BrandName name,
        BrandDescription description,
        List<Product> products)
        : base(id)
    {
        Name = name;
        Description = description;
        Products = products;
    }

    /// <summary>
    /// Creates a new brand.
    /// </summary>
    /// <param name="id">The unique identifier of the brand.</param>
    /// <param name="name">The name of the brand.</param>
    /// <param name="description">The description of the brand.</param>
    /// <param name="products">The list of products associated with the brand.</param>
    /// <param name="isBrandNameUnique">A value indicating whether the brand name is unique.</param>
    /// <returns>A new brand instance.</returns>
    public static Result<Brand> Create(
        BrandId id,
        BrandName name,
        BrandDescription description,
        List<Product> products,
        bool isBrandNameUnique)
    {
        if (!isBrandNameUnique)
        {
            return Result.Failure<Brand>(
                BrandErrors.BrandNameIsNotUnique);
        }

        Brand brand = new Brand(id, name, description, products);

        // Raise a domain event indicating the creation of a new brand
        brand.AddDomainEvent(
            new BrandCreatedDomainEvent(Guid.NewGuid(), id));

        return brand;
    }
}
