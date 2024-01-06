namespace Services.Common.Domain.Primitives.Results;

/// <summary>
/// Class generic for result.
/// </summary>
/// <typeparam name="TValue"> The value of the result.</typeparam>
public class Result<TValue> : Result
{
    /// <summary>
    /// The value of the result.
    /// </summary>
    private readonly TValue _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue}"/> class.
    /// </summary>
    /// <param name="value"> The value.</param>
    /// <param name="isSuccess"> The success flag.</param>
    /// <param name="error"> The error.</param>
    protected internal Result(TValue value, bool isSuccess, Error error)
        : base(isSuccess, error)
        => _value = value;

    /// <summary>
    /// Result value if value null return exception
    /// </summary>
    public TValue Value => IsSuccess
        ? _value
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    /// <summary>
    /// Create a success result.
    /// </summary>
    /// <param name="value"> The result value.</param>
    public static implicit operator Result<TValue>(TValue value) => Success(value);
}
