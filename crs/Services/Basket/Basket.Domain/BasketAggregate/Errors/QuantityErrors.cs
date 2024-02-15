namespace Basket.Domain.BasketAggregate.ValueObjects;

public static class QuantityErrors
{
    public static Error QuantityMustBeGreaterThanZero =>
        new("Quantity.QuantityMustBeGreaterThanZero", "Quantity must be greater than zero");
}
