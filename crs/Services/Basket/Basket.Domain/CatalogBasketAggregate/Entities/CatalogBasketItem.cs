namespace Basket.Domain.CatalogBasketAggregate.Entities;

public class CatalogBasketItem : Entity<CatalogBasketItemId>
{
    public CatalogProduct Product { get; private set; }
    public Quantity Quantity { get; private set; }

    private CatalogBasketItem(CatalogBasketItemId id, CatalogProduct product, Quantity quantity) =>
        (Id, Product, Quantity) = (id, product, quantity);

    public static Result<CatalogBasketItem> Create(CatalogBasketItemId id, CatalogProduct product, Quantity quantity)
    {
        var catalogBasketItem = new CatalogBasketItem(id, product, quantity);

        return catalogBasketItem;
    }

    public Result SetQuantity(int quantity)
    {
        if (quantity > Product.Quantity)
        {
            return Result.Failure(
                CatalogBasketItemErrors.QuantityExceedsProductCount);
        }

        var quantityResult = Quantity.Create(quantity);

        if (quantityResult.IsFailure)
        {
            return Result.Failure(quantityResult.Error);
        }

        return Result.Success();
    }

    public Result AddQuantity(int quantity) =>
        SetQuantity(Quantity.Value + quantity);
}
