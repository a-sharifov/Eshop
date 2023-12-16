namespace Services.Common.App;

public abstract class ApiController : ControllerBase
{
    protected readonly ISender _sender;

    protected ApiController(ISender sender) => _sender = sender;

    protected IActionResult HandleFailure(Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidCastException();
        }

        if (result is IValidationResult validationResult)
        {
            return BadRequest(
                CreateProblemDetails(
                    "Validation error",
                    StatusCodes.Status400BadRequest,
                    result.Error,
                    validationResult.Errors
                )
            );
        }

        return BadRequest(
            CreateProblemDetails(
                "Bad Request",
                StatusCodes.Status400BadRequest,
                result.Error
            )
        );
    }

    // ProblemDetails is a new type in .NET 5 that allows you to return a
    // structured error response without having to create a custom type.
    // The ProblemDetails type is a good choice for returning errors that
    // occur in response to client requests. For errors within your code,
    // you should continue to use the Exception class.
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
