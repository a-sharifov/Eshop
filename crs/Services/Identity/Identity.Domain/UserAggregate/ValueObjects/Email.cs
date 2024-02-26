using Identity.Domain.UserAggregate.Regexes;

namespace Identity.Domain.UserAggregate.ValueObjects;

public sealed partial class Email : ValueObject
{
    public const int MaxLength = 100;

    public string Value { get; private set; }

    private Email(string value) => Value = value;

    public static Result<Email> Create(string email)
    {
        if (email.IsNullOrWhiteSpace())
        {
            return Result.Failure<Email>(
                EmailErrors.CannotByEmpty);
        }

        email = email.Trim();

        if (email.Length > MaxLength)
        {
            return Result.Failure<Email>(
                EmailErrors.CannotBeLongerThan(MaxLength));
        }

        if (!IsEmail(email))
        {
            return Result.Failure<Email>(
                EmailErrors.IsInvalid);
        }

        return new Email(email);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static bool IsEmail(string email) => 
        EmailRegex.Regex().IsMatch(email);

    public static implicit operator string(Email email) => email.Value;
}
