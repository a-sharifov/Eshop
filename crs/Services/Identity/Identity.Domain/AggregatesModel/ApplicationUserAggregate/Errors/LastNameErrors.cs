namespace Identity.Domain.AggregatesModel.UserAggregate.Errors;

public class LastNameErrors
{
    public static Error CannotBeEmpty =>
        new("LastName.Creator", "Last name cannot be empty.");

    public static Error CannotBeLongerThan(int maxLength) =>
        new("LastName.Creator", $"Last name cannot be longer than {maxLength} characters");
}
