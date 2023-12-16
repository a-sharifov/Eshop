namespace Catalog.Domain.AggregatesModel.ProductAggregate.ValueObjects;

public sealed class ProductDescription : ValueObject
{
    public string Value { get; private set; }
    public const int MaxLength = 1000;

    private ProductDescription(string value) => Value = value;

    public static Result<ProductDescription> Create(string value)
    {
        if (value.Length > MaxLength)
        {
            return Result.Failure<ProductDescription>(
                ProductDescriptionErrors.CannotBeLongerThan(MaxLength));
        }

        return new ProductDescription(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}