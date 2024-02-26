namespace Basket.Domain.CatalogBasketAggregate.ValueObjects;

public sealed partial class ImageUrl : ValueObject
{
    public string Value { get; private set; }

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

    public static bool IsImageUrl(string imageUrl) => 
        ImageUrlRegex.Regex().IsMatch(imageUrl);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(ImageUrl imageUrl) => imageUrl.Value;
}