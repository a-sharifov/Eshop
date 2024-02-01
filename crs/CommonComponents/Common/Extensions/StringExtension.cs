namespace Common.Extensions;

/// <summary>
/// Class for string extension.
/// </summary>
public static class StringExtension
{
    /// <summary>
    /// Checks if the string is null or empty.
    /// </summary>
    /// <param name="str"> The string to check.</param>
    /// <returns> True if the string is null or empty.</returns>
    public static bool IsNullOrEmpty(this string? str) =>
        string.IsNullOrEmpty(str);

    /// <summary>
    /// Checks if the string is not null or empty.
    /// </summary>
    /// <param name="str"> The string to check.</param>
    /// <returns> True if the string is not null or empty.</returns>
    public static bool IsNotNullOrEmpty(this string str) =>
        !str.IsNullOrEmpty();

    /// <summary>
    /// Checks if the string is null or white space.
    /// </summary>
    /// <param name="str"> The string to check.</param>
    /// <returns> True if the string is null or white space.</returns>
    public static bool IsNullOrWhiteSpace(this string? str) =>
        string.IsNullOrWhiteSpace(str);

    /// <summary>
    /// Checks if the string is not null or white space.
    /// </summary>
    /// <param name="str"> The string to check.</param>
    /// <returns> True if the string is not null or white space.</returns>
    public static bool IsNotNullOrWhiteSpace(this string? str) =>
        !str.IsNullOrWhiteSpace();
}
