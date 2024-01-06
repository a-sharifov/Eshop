namespace Identity.Domain.UserAggregate.Errors;

public class LastNameErrors
{
    public static Error CannotBeEmpty =>
        new("LastName.CannotBeEmpty", "Last name cannot be empty.");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("LastName.CannotBeLongerThan", $"Last name cannot be longer than {maxLength} characters");
}
