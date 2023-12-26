namespace Identity.Domain.UserAggregate.ValueObjects;

public sealed class FirstName : ValueObject
{
    public const int MaxLength = 50;

    public string Value { get; private set; }

    private FirstName(string value) =>
        Value = value;

    public static Result<FirstName> Create(string firstName)
    {
        if (firstName.IsNullOrWhiteSpace())
        {
            return Result.Failure<FirstName>(
                FirstNameErrors.CannotBeEmpty);
        }

        if (firstName.Length > MaxLength)
        {
            return Result.Failure<FirstName>(
                FirstNameErrors.CannotBeLongerThan(MaxLength));
        }

        return new FirstName(firstName);
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
