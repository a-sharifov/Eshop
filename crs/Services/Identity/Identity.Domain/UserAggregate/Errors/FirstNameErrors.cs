namespace Identity.Domain.UserAggregate.Errors;

public static class FirstNameErrors
{
    public static Error CannotBeEmpty =>
        new("FirstName.CannotBeEmpty", "First name cannot be empty.");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("FirstName.CannotBeLongerThan", $"First name cannot be longer than {maxLength} characters");
}