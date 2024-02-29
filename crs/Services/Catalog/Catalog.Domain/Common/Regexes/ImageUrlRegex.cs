namespace Catalog.Domain.Common.Regexes;

public partial class ImageUrlRegex
{
    private const string ImageUrlPattern = @"^(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png)$";

    [GeneratedRegex(ImageUrlPattern)]
    public static partial Regex Regex();
}
