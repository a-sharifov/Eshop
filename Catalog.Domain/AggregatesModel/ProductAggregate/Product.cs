namespace Catalog.Domain.AggregatesModel.ProductAggregate;

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

    public Product(
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

        AddDomainEvent(new ProductCreatedDomainEvent(Guid.NewGuid(), Id));
    }
}