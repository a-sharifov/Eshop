using Catalog.Domain.Common.Errors;

namespace Catalog.Domain.Common.ValueObjects;

public sealed class Money : ValueObject
{
    public string Currency { get; private set; }
    public decimal Amount { get; private set; }

    public bool PriceIsNegative => Amount >= 0;
    public bool PriceIsNotNegative => !PriceIsNotNegative;

    private Money(string currency, decimal amount) =>
        (Currency, Amount) = (currency, amount);

    public static Result<Money> Create(string currency, decimal amount)
    {
        if (currency.IsNullOrWhiteSpace())
        {
            return Result.Failure<Money>(
                MoneyErrors.CannotBeEmpty);
        }

        return new Money(currency, amount);
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Currency;
        yield return Amount;
    }

    public static implicit operator decimal(Money money) => money.Amount;
}