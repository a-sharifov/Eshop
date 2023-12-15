namespace Services.Common.Extensions;

public static class EnumerableExtension
{
    public static void Foreach<T>(this IEnumerable<T> values, Action<T> action)
    {
        foreach (var value in values)
        {
            action.Invoke(value);
        }
    }
}
