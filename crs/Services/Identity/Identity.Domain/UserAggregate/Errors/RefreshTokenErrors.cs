namespace Identity.Domain.UserAggregate.Errors;

public class RefreshTokenErrors
{
    public static Error CannotBeEmpty =>
        new Error("RefreshToken.CannotBeEmpty", "Refresh token should not be empty");

    public static Error CannotBeExpired =>
        new Error("RefreshToken.CannotBeExpired", "Refresh token should not be expired");
}
