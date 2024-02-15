namespace Basket.Domain.BasketAggregate.ValueObjects;

public sealed class Quantity : ValueObject
{
    public int Value { get; private set; }

    private Quantity(int value) => Value = value;

    public static Result<Quantity> Create(int value)
    {
        if (value < 0)
        {
            return Result.Failure<Quantity>(
                QuantityErrors.QuantityMustBeGreaterThanZero);
        }

        return new Quantity(value);
    }

    public static Quantity Empty => new(0);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}