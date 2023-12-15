namespace Services.Common.App;

public abstract class ApiController : ControllerBase
{
    protected readonly ISender _sender;

    protected ApiController(ISender sender) => _sender = sender;

    protected IActionResult HandleFailure(Result result) =>
        result switch
        {
            { IsSuccess: true } => throw new InvalidCastException(),
            IValidationResult validationResult => BadRequest(
                CreateProblemDetails(
                    "Validation error",
                    StatusCodes.Status400BadRequest,
                    result.Error,
                    validationResult.Errors
                    )
                ),
            _ => BadRequest(
                CreateProblemDetails(
                    "Bad Request",
                    StatusCodes.Status400BadRequest,
                    result.Error
                    )
                )
        };

    private static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null) =>
        new()
        {
            Title = title,
            Status = status,
            Detail = error.Message,
            Type = $"https://httpstatuses.com/{status}",
            Extensions =
            {
                { nameof(errors),  errors  }
            }
        };
}
