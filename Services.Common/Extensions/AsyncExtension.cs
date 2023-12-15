namespace Services.Common.Extensions;

public static class AsyncExtension
{
    public static void GetResult(this Task task) =>
        task.ConfigureAwait(false).GetAwaiter().GetResult();

    public static T GetResult<T>(this Task<T> task) =>
        task.ConfigureAwait(false).GetAwaiter().GetResult();
}
