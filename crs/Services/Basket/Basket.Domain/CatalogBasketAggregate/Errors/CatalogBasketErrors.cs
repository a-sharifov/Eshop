namespace Basket.Domain.CatalogBasketAggregate.Errors;

public static class CatalogBasketErrors
{
    public static Error BasketItemDoesNotExist => 
        new("Basket.BasketItemDoesNotExist", "Basket item does not exist.");

    public static Error UserBasketExist =>
        new("Basket.UserBasketExist", "User basket already exists.");
}
