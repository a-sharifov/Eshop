namespace Common.Infrastructure.Middleware;

/// <summary>
/// Class for exception handling middleware.
/// </summary>
/// <param name="next"> The next request delegate.</param>
/// <param name="logger"> The logger.</param>
public sealed class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    /// <summary>
    /// The next request delegate.
    /// </summary>
    private readonly RequestDelegate _next = next;

    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

    /// <summary>
    /// Invoke async the middleware.
    /// </summary>
    /// <param name="context"> The <see cref="HttpContext"/>.</param>
    /// <returns> A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
           
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            };

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            // write the problem details response
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
