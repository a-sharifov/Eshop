namespace Basket.Domain.CatalogBasketAggregate;

public sealed class CatalogBasket : AggregateRoot<CatalogBasketId>
{
    private readonly UserId UserId;
    private readonly List<CatalogBasketItem> _basketItems = [];
    public IReadOnlyCollection<CatalogBasketItem> BasketItems => _basketItems.AsReadOnly();

    private CatalogBasket(CatalogBasketId id, UserId userId)
    {
        Id = id;
        UserId = userId;
        _basketItems = [];
    }

    public static Result<CatalogBasket> Create(CatalogBasketId id, UserId userId, bool isUserBasketExist)
    {
        if (isUserBasketExist)
        {
            return Result.Failure<CatalogBasket>(
                CatalogBasketErrors.UserBasketExist);
        }

        CatalogBasket basket = new(id, userId);
        basket.AddDomainEvent(
            new CatalogBasketCreatedDomainEvent(Guid.NewGuid(), id));

        return basket;
    } 

    public void AddItem(CatalogBasketItem basketItem, int quantity)
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

    public Result SetQuantity(CatalogBasketItemId basketItemId, int quantity)
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

    public Result AddQuantity(CatalogBasketItemId basketItemId, int quantity)
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

    public Result RemoveItem(CatalogBasketItemId basketItemId)
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

    public Result<CatalogBasketItem> GetBasketItemById(CatalogBasketItemId basketItemId)
    {
        var existingItem = _basketItems.SingleOrDefault(basketItem => basketItem.Id == basketItemId);

        if (existingItem == null)
        {
            return Result.Failure<CatalogBasketItem>(
                CatalogBasketErrors.BasketItemDoesNotExist);
        }

        return existingItem;
    }

    public void ClearItems() => _basketItems.Clear();
}
