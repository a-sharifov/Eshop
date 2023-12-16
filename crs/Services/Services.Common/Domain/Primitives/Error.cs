namespace Services.Common.Domain.Primitives;

public sealed record Error(string Code, string Message)
{
    internal static Error None => new Error(string.Empty, string.Empty);

    public static implicit operator string(Error error) => error?.Code ?? string.Empty;
}
