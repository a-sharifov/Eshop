namespace Basket.Domain.CatalogBasketAggregate.Entities;

public class CatalogBasketItem : Entity<CatalogBasketItemId>
{
    public CatalogProduct Product { get; private set; }
    public Quantity Quantity { get; private set; }

    private CatalogBasketItem(CatalogBasketItemId id, CatalogProduct product, Quantity quantity) =>
        (Id, Product, Quantity) = (id, product, quantity);

    public static Result<CatalogBasketItem> Create(CatalogBasketItemId id, CatalogProduct product, Quantity quantity)
    {
        if (quantity <= 0)
        {
            return Result.Failure<CatalogBasketItem>(
                CatalogBasketItemErrors.QuantityMustBeGreaterThanZero);
        }

        return new CatalogBasketItem(id, product, quantity);
    }

    public Result AddQuantity(int quantity) => SetQuantity(Quantity + quantity);

    public Result SetQuantity(int quantity)
    {
        if (quantity < 0)
        {
            return Result.Failure(
                CatalogBasketItemErrors.QuantityMustBeGreaterThanZero);
        }

        if (quantity > Product.Quantity)
        {
            return Result.Failure(
                CatalogBasketItemErrors.QuantityExceedsProductCount);
        }

        Quantity = quantity;
        return Result.Success();
    }
}
