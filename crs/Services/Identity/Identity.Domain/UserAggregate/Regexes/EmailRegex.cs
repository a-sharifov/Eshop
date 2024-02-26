namespace Identity.Domain.UserAggregate.Regexes;

public partial class EmailRegex
{
    private const string EmailPattern = @"^(.+)@(.+)$";

    [GeneratedRegex(EmailPattern)]
    public static partial Regex Regex();
}
