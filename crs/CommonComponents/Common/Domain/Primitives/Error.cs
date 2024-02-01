namespace Common.Domain.Primitives;

/// <summary>
/// Class for error.
/// </summary>
/// <param name="Code"> The code of the error.</param>
/// <param name="Message"> The message of the error.</param>
public sealed record Error(string Code, string Message)
{
    /// <summary>
    /// Gets the none error.
    /// </summary>
    internal static Error None => new(string.Empty, string.Empty);

    /// <summary>
    /// Gets the code of the error.
    /// </summary>
    /// <param name="error"> The error.</param>
    public static implicit operator string(Error error) => error?.Code ?? string.Empty;
}
