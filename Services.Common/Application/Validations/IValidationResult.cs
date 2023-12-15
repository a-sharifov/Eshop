namespace Services.Common.Application.Validations;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        "ValidationError",
        "A validation problem.");

    Error[] Errors { get; }
}
