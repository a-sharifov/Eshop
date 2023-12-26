namespace Identity.Domain.UserAggregate.Errors;

public static class UserErrors
{
    public static Error EmailIsNotUnique(string email) =>
        new("User.Creator", $"Email {email} is not unique.");

    public static Error EmailIsNotConfirmed =>
        new("User.Creator", $"Email is not confirmed.");

    public static Error PasswordIsNotCorrect =>
        new("User.Creator", $"Password is not correct.");
}
