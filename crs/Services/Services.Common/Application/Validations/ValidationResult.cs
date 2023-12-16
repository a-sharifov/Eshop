namespace Services.Common.Application.Validations;

public sealed class ValidationResult : Result, IValidationResult
{
    private ValidationResult(Error[] errors)
        : base(false, IValidationResult.ValidationError) =>
        Errors = errors;

    public Error[] Errors { get; private set; }

    public static ValidationResult WithErrors(params Error[] errors) => new(errors);
}
