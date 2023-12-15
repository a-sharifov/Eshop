namespace Services.Common.Extensions;

public static class StringExtension
{
    public static bool IsNullOrEmpty(this string? str) =>
        string.IsNullOrEmpty(str);

    public static bool IsNotNullOrEmpty(this string str) =>
        !str.IsNullOrEmpty();

    public static bool IsNullOrWhiteSpace(this string? str) =>
        string.IsNullOrWhiteSpace(str);

    public static bool IsNotNullOrWhiteSpace(this string? str) =>
        !str.IsNullOrWhiteSpace();
}
