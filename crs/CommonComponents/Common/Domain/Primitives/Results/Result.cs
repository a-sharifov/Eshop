namespace Common.Domain.Primitives.Results;

/// <summary>
/// class for result pattern.
/// </summary>
public class Result
{
    /// <summary>
    /// Gets a value indicating whether the result is success.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets a value indicating whether the result is failure.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the error.
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// initialize a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="isSuccess"> The success.</param>
    /// <param name="error"> The error.</param>
    /// <exception cref="ArgumentException"></exception>
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException(
                "invalid entry parameter");
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>
    /// Create a success result.
    /// </summary>
    /// <returns> The result.</returns>
    public static Result Success() => new(true, Error.None);

    /// <summary>
    /// Create a Success return value.
    /// </summary>
    /// <typeparam name="TValue"> The value type.</typeparam>
    /// <param name="value"> The value.</param>
    /// <returns> The result.</returns>
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    /// <summary>
    /// Create a result.
    /// if the value is null, return a failure result.
    /// else return a success result.
    /// </summary>
    /// <typeparam name="TValue"> The value type.</typeparam>
    /// <param name="value"> The value.</param>
    /// <param name="error"> The error.</param>
    /// <returns> The result.</returns>
    public static Result<TValue> Create<TValue>(TValue value, Error error)
        where TValue : class
        => value is null ? Failure<TValue>(error) : Success(value);

    /// <summary>
    /// Create a failure result.
    /// </summary>
    /// <param name="error"> The error.</param>
    /// <returns> The result.</returns>
    public static Result Failure(Error error) => new(false, error);

    /// <summary>
    /// Create a failure generic result.
    /// </summary>
    /// <typeparam name="TValue"> The value type.</typeparam>
    /// <param name="error"> The error.</param>
    /// <returns> The result.</returns>
    public static Result<TValue> Failure<TValue>(Error error) => new(default!, false, error);

    /// <summary>
    /// get first failure result or success result.
    /// </summary>
    /// <param name="results"> The results.</param>
    /// <returns> The result.</returns>
    public static Result FirstFailureOrSuccess(params Result[] results)
    {
        foreach (Result result in results)
        {
            if (result.IsFailure)
            {
                return result;
            }
        }

        return Success();
    }
}
