namespace Identity.Domain.UserAggregate.ValueObjects;

public sealed class PasswordSalt : ValueObject
{
    public string Value { get; private set; }

    private PasswordSalt(string value) =>
        Value = value;

    public static Result<PasswordSalt> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<PasswordSalt>(
                PasswordSaltError.CannotBeEmpty);
        }

        if (value.Length < 8)
        {
            return Result.Failure<PasswordSalt>(
                PasswordSaltError.TooShort);
        }

        return new PasswordSalt(value);
    }

    public static implicit operator string(PasswordSalt passwordSalt)
    {
        return passwordSalt.Value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}