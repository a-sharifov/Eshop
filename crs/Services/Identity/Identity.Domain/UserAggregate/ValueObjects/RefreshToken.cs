namespace Identity.Domain.UserAggregate.ValueObjects;

public sealed class RefreshToken : ValueObject
{
    public string Token { get; private set; }
    public DateTime Expired { get; private set; }

    public bool IsExpired => DateTime.UtcNow >= Expired;

    private RefreshToken(string token, DateTime expired) =>
        (Token, Expired) = (token, expired);

    public static Result<RefreshToken> Create(string value, DateTime expires)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<RefreshToken>(
                RefreshTokenErrors.CannotBeEmpty);
        }

        if (expires < DateTime.UtcNow)
        {
            return Result.Failure<RefreshToken>(
                RefreshTokenErrors.CannotBeExpired);
        }

        return new RefreshToken(value, expires);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Token;
        yield return Expired;
    }
}
