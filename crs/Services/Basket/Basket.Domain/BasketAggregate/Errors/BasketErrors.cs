namespace Basket.Domain.BasketAggregate.Errors;

public static class BasketErrors
{
    public static Error BasketItemDoesNotExist => 
        new("Basket.BasketItemDoesNotExist", "Basket item does not exist.");

    public static Error UserBasketExist =>
        new("Basket.UserBasketExist", "User basket already exists.");
}
