namespace Basket.Domain.CatalogBasketAggregate.Entities;

public class CatalogProduct : Entity<CatalogProductId>
{
    public ProductId ProductId { get; private set; }
    public CatalogProductName CatalogProductName { get; private set; }
    public Money Price { get; private set; }
    public ImageUrl ProductImage { get; private set; }
    public Quantity Quantity { get; private set; }

    private CatalogProduct(
        CatalogProductId catalogProductId,
        ProductId productId,
        CatalogProductName catalogProductName,
        Money price,
        ImageUrl productImage,
        Quantity quantity)
    {
        Id = catalogProductId;
        ProductId = productId;
        CatalogProductName = catalogProductName;
        Price = price;
        ProductImage = productImage;
        Quantity = quantity;
    }

    public static Result<CatalogProduct> Create(
        CatalogProductId catalogProductId,
        ProductId productId,
        CatalogProductName catalogProductName,
        Money price,
        ImageUrl productImage,
        Quantity quantity)
    {
        var catalogProduct = new CatalogProduct(
            catalogProductId,
            productId,
            catalogProductName,
            price,
            productImage,
            quantity);

        return catalogProduct;
    }
}
