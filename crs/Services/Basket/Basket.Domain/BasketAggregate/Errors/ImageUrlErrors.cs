﻿namespace Basket.Domain.BasketAggregate.ValueObjects;

public static class ImageUrlErrors
{
    public static Error CannotByEmpty =>
        new("ImageUrl.CannotByEmpty", "Image url cannot be empty");

    public static Error IsInvalid =>
        new("ImageUrl.IsInvalid", "Image url is invalid");
}