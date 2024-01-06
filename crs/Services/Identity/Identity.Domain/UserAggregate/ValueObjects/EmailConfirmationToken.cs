namespace Identity.Domain.UserAggregate.ValueObjects;

public sealed class EmailConfirmationToken : ValueObject
{
    public string Value { get; private set; }

    private EmailConfirmationToken(string value) =>
        Value = value;

    public static Result<EmailConfirmationToken> Create(string value)
    {
        if (value.IsNullOrWhiteSpace())
        {
            return Result.Failure<EmailConfirmationToken>(
                EmailConfirmationTokenErrors.InvalidEmailConfirmationToken());
        }

        return Result.Success(new EmailConfirmationToken(value));
    }

    public static implicit operator EmailConfirmationToken(string token) =>
        Create(token).Value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}