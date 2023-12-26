using Identity.Domain.UserAggregate.Errors;

namespace Identity.Domain.UserAggregate.ValueObjects;

public sealed class LastName : ValueObject
{
    public const int MaxLength = 50;

    public string Value { get; private set; }

    private LastName(string value) =>
        Value = value;

    public static Result<LastName> Create(string lastName)
    {
        if (lastName.IsNullOrWhiteSpace())
        {
            return Result.Failure<LastName>(
                LastNameErrors.CannotBeEmpty);
        }

        if (lastName.Length > MaxLength)
        {
            return Result.Failure<LastName>(
                LastNameErrors.CannotBeLongerThan(MaxLength));
        }

        return new LastName(lastName);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
