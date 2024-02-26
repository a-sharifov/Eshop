namespace Basket.Domain.CatalogBasketAggregate.Errors;

public static class CatalogBasketItemErrors
{
    public static Error QuantityMustBeGreaterThanZero => 
        new("BasketItem.QuantityMustBeGreaterThanZero", "Quantity must be greater than zero");

    public static Error QuantityExceedsProductCount =>
        new("BasketItem.QuantityExceedsProductCount", "Quantity exceeds product count");

}
