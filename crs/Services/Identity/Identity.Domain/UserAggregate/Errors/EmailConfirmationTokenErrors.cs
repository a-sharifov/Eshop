namespace Identity.Domain.UserAggregate.Errors;

public static class EmailConfirmationTokenErrors
{
    public static Error InvalidEmailConfirmationToken() =>
        new Error("invalid_email_confirmation_token", "Invalid email confirmation token.");
}