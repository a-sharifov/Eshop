namespace Basket.Domain.BasketAggregate.Errors;

public static class BasketItemErrors
{
    public static Error QuantityMustBeGreaterThanZero => 
        new("BasketItem.QuantityMustBeGreaterThanZero", "Quantity must be greater than zero");

    public static Error QuantityExceedsProductCount =>
        new("BasketItem.QuantityExceedsProductCount", "Quantity exceeds product count");

}
