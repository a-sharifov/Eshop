namespace Basket.Domain.BasketAggregate.ValueObjects;

public sealed partial class ImageUrl : ValueObject
{
    public string Value { get; private set; }

    private const string ImageUrlPattern = @"^(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png)$";

    private ImageUrl(string value) => Value = value;


    public static Result<ImageUrl> Create(string imageUrl)
    {
        if (imageUrl.IsNullOrWhiteSpace())
        {
            return Result.Failure<ImageUrl>(
                ImageUrlErrors.CannotByEmpty);
        }

        imageUrl = imageUrl.Trim();

        if (!IsImageUrl(imageUrl))
        {
            return Result.Failure<ImageUrl>(
                ImageUrlErrors.IsInvalid);
        }

        return new ImageUrl(imageUrl);
    }

    public static bool IsImageUrl(string imageUrl) => ImageUrlRegex().IsMatch(imageUrl);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(ImageUrl imageUrl) => imageUrl.Value;

    [GeneratedRegex(ImageUrlPattern)]
    private static partial Regex ImageUrlRegex();
}