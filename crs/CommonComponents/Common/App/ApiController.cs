namespace Common.App;

/// <summary>
/// Base class for API controllers.
/// </summary>
[ApiController]
public abstract class ApiController : ControllerBase
{
    /// <summary>
    /// The sender.
    /// </summary>
    protected readonly ISender _sender;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiController"/> class.
    /// </summary>
    /// <param name="sender"> The sender.</param>
    protected ApiController(ISender sender) => _sender = sender;

    /// <summary>
    /// Handles the result of a request.
    /// </summary>
    /// <param name="result"> The result.</param>
    /// <returns> The result.</returns>
    /// <exception cref="InvalidCastException"> Thrown when the result is a success.</exception>
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

    /// <summary>
    /// Handles the result of a request.
    /// </summary>
    /// <param name="title"> The title.</param>
    /// <param name="status"> The status.</param>
    /// <param name="error"> The error.</param>
    /// <param name="errors"> The errors.</param>
    /// <returns></returns>
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
