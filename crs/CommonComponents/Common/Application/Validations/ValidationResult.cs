namespace Common.Application.Validations;

/// <summary>
/// Class for validation result.
/// </summary>
public sealed class ValidationResult : Result, IValidationResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationResult"/> class.
    /// </summary>
    /// <param name="errors"></param>
    private ValidationResult(Error[] errors)
        : base(false, IValidationResult.ValidationError) =>
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
    public static ValidationResult WithErrors(params Error[] errors) => new(errors);
}
