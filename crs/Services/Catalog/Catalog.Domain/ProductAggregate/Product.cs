using Catalog.Domain.BrandAggregate;
using Catalog.Domain.CategoryAggregate;
using Catalog.Domain.Common.ValueObjects;
using Catalog.Domain.ProductAggregate.Ids;
using Catalog.Domain.ProductAggregate.ValueObjects;
using Catalog.Domain.SellerAggregate;

namespace Catalog.Domain.ProductAggregate;

public class Product : AggregateRoot<ProductId>
{
    public Sku Sku { get; private set; }
    public ProductName Name { get; private set; }
    public Money Price { get; private set; }
    public Category Category { get; private set; }
    public Seller Seller { get; private set; }
    public Brand Brand { get; private set; }
    public ImageUrl ProductImage { get; private set; }
    public ProductDescription Description { get; private set; }

    private Product()
    {
    }

    private Product(
        ProductId id,
        Sku sku,
        ProductName name,
        Money price,
        Category category,
        Seller seller,
        Brand brand,
        ImageUrl productImage,
        ProductDescription description)
        : base(id)
    {
        Sku = sku;
        Name = name;
        Price = price;
        Category = category;
        Seller = seller;
        Brand = brand;
        ProductImage = productImage;
        Description = description;
    }

    public static Result<Product> Create(
        ProductId id,
        Sku sku,
        ProductName name,
        Money price,
        Category category,
        Seller seller,
        Brand brand,
        ImageUrl productImage,
        ProductDescription description)
    {
        var product = new Product(
            id,
            sku,
            name,
            price,
            category,
            seller,
            brand,
            productImage,
            description);

        product.AddDomainEvent(
            new ProductCreatedDomainEvent(Guid.NewGuid(), id));

        return product;
    }
}