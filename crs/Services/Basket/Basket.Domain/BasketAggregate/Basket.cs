namespace Basket.Domain.BasketAggregate;

public sealed class Basket : AggregateRoot<BasketId>
{
    private readonly UserId UserId;
    private readonly List<BasketItem> _basketItems = [];
    public IReadOnlyCollection<BasketItem> BasketItems => _basketItems.AsReadOnly();

    private Basket(BasketId id, UserId userId)
    {
        Id = id;
        UserId = userId;
        _basketItems = [];
    }

    public static Result<Basket> Create(BasketId id, UserId userId, bool isUserBasketExist)
    {
        if (isUserBasketExist)
        {
            return Result.Failure<Basket>(
                BasketErrors.UserBasketExist);
        }

        Basket basket = new(id, userId);
        basket.AddDomainEvent(
            new BasketCreatedDomainEvent(Guid.NewGuid(), id));

        return basket;
    } 

    public void AddItem(BasketItem basketItem, int quantity)
    {
        var existingItem = _basketItems
            .SingleOrDefault(basketItem => basketItem.Id == basketItem.Id);

        if (existingItem != null)
        {
            existingItem.AddQuantity(quantity);
            return;
        }

        _basketItems.Add(basketItem);
    }

    public void RemoveEmptyItems() => 
        _basketItems.RemoveAll(x => x.Quantity == 0);

    public Result SetQuantity(BasketItemId basketItemId, int quantity)
    {
        var basketItemResult = GetBasketItemById(basketItemId);

        if (basketItemResult.IsFailure)
        {
            return Result.Failure(
                basketItemResult.Error);
        }

        basketItemResult.Value.SetQuantity(quantity);
        return Result.Success();
    }

    public Result AddQuantity(BasketItemId basketItemId, int quantity)
    {
        var basketItemResult = GetBasketItemById(basketItemId);

        if (basketItemResult.IsFailure)
        {
            return Result.Failure(
                basketItemResult.Error);
        }

        basketItemResult.Value.AddQuantity(quantity);

        return Result.Success();
    }

    public Result RemoveItem(BasketItemId basketItemId)
    {
       var basketItemResult = GetBasketItemById(basketItemId);

        if (basketItemResult.IsFailure)
        {
            return Result.Failure(
                basketItemResult.Error);
        }

        _basketItems.Remove(basketItemResult.Value);

        return Result.Success();
    }

    public Result<BasketItem> GetBasketItemById(BasketItemId basketItemId)
    {
        var existingItem = _basketItems.SingleOrDefault(basketItem => basketItem.Id == basketItemId);

        if (existingItem == null)
        {
            return Result.Failure<BasketItem>(
                BasketErrors.BasketItemDoesNotExist);
        }

        return existingItem;
    }

    public void ClearItems() => _basketItems.Clear();
}
