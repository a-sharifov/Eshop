namespace Identity.Domain.AggregatesModel.UserAggregate.ValueObjects;

public sealed class UserName : ValueObject
{
    private const int MaxLength = 50;

    public string Value { get; private set; }

    private UserName(string value) =>
        Value = value;

    public static Result<UserName> Create(string userName)
    {
        if (userName.IsNullOrWhiteSpace())
        {
            return Result.Failure<UserName>(
                UserNameErrors.CannotBeEmpty);
        }

        if (userName.Length > MaxLength)
        {
            return Result.Failure<UserName>(
                UserNameErrors.CannotBeLongerThan(MaxLength));
        }

        return Result.Success(new UserName(userName));
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
