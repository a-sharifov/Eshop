namespace Catalog.Domain.AggregatesModel.Common.Errors;

public static class ImageUrlErrors
{
    public static Error CannotByEmpty =>
        new Error("ImageUrl.Creator", "Image url cannot be empty");

    public static Error IsInvalid =>
        new Error("ImageUrl.Creator", "Image url is invalid");
}