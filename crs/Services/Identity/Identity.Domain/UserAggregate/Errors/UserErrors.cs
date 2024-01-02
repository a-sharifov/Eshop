namespace Identity.Domain.UserAggregate.Errors;

public static class UserErrors
{
    public static Error EmailIsNotUnique(string email) =>
        new("User.EmailIsNotUnique", $"Email {email} is not unique.");

    public static Error EmailIsNotConfirmed =>
        new("User.EmailIsNotConfirmed", $"Email is not confirmed.");

    public static Error PasswordIsNotCorrect =>
        new("User.PasswordIsNotCorrect", $"Password is not correct.");

    public static Error UserDoesNotExist =>
        new("User.UserDoesNotExist", $"User does not exist.");

    public static Error EmailIsNotExists(string email) => 
        new("User.EmailIsNotExists", $"Email {email} is not exists.");

    public static Error RefreshTokenIsNotExists =>
        new("User.RefreshTokenIsNotExists", $"Refresh token is not exists.");

    public static Error RefreshTokenIsExpired => 
        new("User.RefreshTokenIsNotValid", $"Refresh token is expired.");
}
