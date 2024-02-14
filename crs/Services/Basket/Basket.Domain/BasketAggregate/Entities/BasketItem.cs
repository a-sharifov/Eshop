namespace Basket.Domain.BasketAggregate.Entities;

public class BasketItem : Entity<BasketItemId>
{
    public CatalogProduct Product { get; private set; }
    public int Quantity { get; private set; }

    private BasketItem(BasketItemId id, CatalogProduct product, int quantity) =>
        (Id, Product, Quantity) = (id, product, quantity);

    public static Result<BasketItem> Create(BasketItemId id, CatalogProduct product, int quantity)
    {
        if (quantity <= 0)
        {
            return Result.Failure<BasketItem>(
                BasketItemErrors.QuantityMustBeGreaterThanZero);
        }

        return new BasketItem(id, product, quantity);
    }

    public Result AddQuantity(int quantity) => SetQuantity(Quantity + quantity);

    public Result SetQuantity(int quantity)
    {
        if (quantity < 0)
        {
            return Result.Failure(
                BasketItemErrors.QuantityMustBeGreaterThanZero);
        }

        if (quantity > Product.Quantity)
        {
            return Result.Failure(
                BasketItemErrors.QuantityExceedsProductCount);
        }

        Quantity = quantity;
        return Result.Success();
    }
}
