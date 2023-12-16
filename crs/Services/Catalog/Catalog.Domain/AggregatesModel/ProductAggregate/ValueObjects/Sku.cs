namespace Catalog.Domain.AggregatesModel.ProductAggregate.ValueObjects;

public class Sku : ValueObject
{
    public const int MaxLength = 20;

    public string Value { get; private set; }

    private Sku(string value) => Value = value;

    public static Result<Sku> Create(string value)
    {
        if (value.IsNullOrEmpty())
        {
            return Result.Failure<Sku>(
                SkuErrors.CannotBeEmpty);
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<Sku>(
                SkuErrors.CannotBeLongerThan(MaxLength));
        }

        return new Sku(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(Sku sku) => sku.Value;
}