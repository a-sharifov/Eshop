
namespace Basket.Domain.BasketAggregate.ValueObjects;

public class CatalogProduct : ValueObject
{
    public ProductId ProductId { get; private set; }
    public CatalogProductName CatalogProductName { get; private set; }
    public Money Price { get; private set; }
    public ImageUrl ProductImage { get; private set; }
    public Quantity Quantity { get; private set; }

    private CatalogProduct(
        ProductId productId,
        CatalogProductName catalogProductName,
        Money price,
        ImageUrl productImage,
        Quantity quantity)
    {
        ProductId = productId;
        CatalogProductName = catalogProductName;
        Price = price;
        ProductImage = productImage;
        Quantity = quantity;
    }

    private static Result<CatalogProduct> Create(
        ProductId productId,
        CatalogProductName catalogProductName,
        Money price,
        ImageUrl productImage,
        Quantity quantity)
    {
        return Result.Success(new CatalogProduct(
            productId,
            catalogProductName,
            price,
            productImage,
            quantity));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return ProductId;
        yield return CatalogProductName;
        yield return Price;
        yield return ProductImage;
        yield return Quantity;
    }
}
