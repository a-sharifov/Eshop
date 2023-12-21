namespace Identity.Domain.AggregatesModel.UserAggregate.ValueObjects;

public sealed class PasswordHash : ValueObject
{
    public const int MinLength = 8;
    public const int MaxLength = 100;

    public string Value { get; private set; }

    private PasswordHash(string value) =>
        Value = value;

    public static Result<PasswordHash> Create(string password)
    {
        if (password.IsNullOrWhiteSpace())
        {
            return Result.Failure<PasswordHash>(
                PasswordHashErrors.CannotBeEmpty);
        }

        if (password.Length < MinLength)
        {
            return Result.Failure<PasswordHash>(
                PasswordHashErrors.CannotBeShorterThan(MinLength));
        }

        if (password.Length > MaxLength)
        {
            return Result.Failure<PasswordHash>(
                PasswordHashErrors.CannotBeLongerThan(MaxLength));
        }

        return Result.Success(new PasswordHash(password));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
