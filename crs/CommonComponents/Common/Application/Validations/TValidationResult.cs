namespace Common.Application.Validations;

/// <summary>
/// Generic class for validation result.
/// </summary>
/// <typeparam name="TValue"> The value type.</typeparam>
public sealed class ValidationResult<TValue> : Result<TValue>, IValidationResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationResult{TValue}"/> class.
    /// </summary>
    /// <param name="errors"> The errors.</param>
    private ValidationResult(Error[] errors)
        : base(default!, false, IValidationResult.ValidationError) =>
        Errors = errors;

    /// <summary>
    /// Gets the validation errors.
    /// </summary>
    public Error[] Errors { get; private set; }

    /// <summary>
    /// Create a validation result.
    /// </summary>
    /// <param name="errors"> The errors.</param>
    /// <returns> The validation result.</returns>
    public static ValidationResult<TValue> WithErrors(params Error[] errors) => new(errors);
}
