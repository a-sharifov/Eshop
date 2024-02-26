namespace Catalog.Domain.Common.Regexes;

public partial class EmailRegex
{
    private const string EmailPattern = @"^(.+)@(.+)$";

    [GeneratedRegex(EmailPattern)]
    public static partial Regex Regex();
}
