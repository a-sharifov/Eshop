namespace Catalog.Domain.Common.Errors;

public static class ImageUrlErrors
{
    public static Error CannotByEmpty =>
        new Error("ImageUrl.CannotByEmpty", "Image url cannot be empty");

    public static Error IsInvalid =>
        new Error("ImageUrl.IsInvalid", "Image url is invalid");
}