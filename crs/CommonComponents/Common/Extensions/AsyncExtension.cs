namespace Common.Extensions;

/// <summary>
/// Class for async extension.
/// </summary>
public static class AsyncExtension
{
    /// <summary>
    /// Gets the result.
    /// </summary>
    /// <param name="task"> <see cref="Task"/>.</param>"/>
    public static void GetResult(this Task task) =>
        task.ConfigureAwait(false).GetAwaiter().GetResult();

    /// <summary>
    /// Gets the result.
    /// </summary>
    /// <typeparam name="T"> The type.</typeparam>
    /// <param name="task"> <see cref="Task{T}"/>.</param>"/>
    /// <returns> The result.</returns>
    public static T GetResult<T>(this Task<T> task) =>
        task.ConfigureAwait(false).GetAwaiter().GetResult();
}
