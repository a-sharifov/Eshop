namespace Common.Application.Validations;

/// <summary>
/// Interface for validation result.
/// </summary>
public interface IValidationResult
{
    /// <summary>
    /// Gets the validation errors.
    /// </summary>
    public static readonly Error ValidationError = new(
        "ValidationError",
        "A validation problem.");

    /// <summary>
    /// Gets the validation errors.
    /// </summary>
    Error[] Errors { get; }
}
