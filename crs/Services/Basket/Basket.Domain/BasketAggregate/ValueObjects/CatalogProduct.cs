namespace Basket.Domain.BasketAggregate.ValueObjects;

public class CatalogProduct : ValueObject
{
    public ProductId ProductId { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Brand { get; private set; }
    public string Category { get; private set; }
    public string ImageUrl { get; private set; }
    public int Quantity { get; private set; }
    public string Sku { get; private set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
