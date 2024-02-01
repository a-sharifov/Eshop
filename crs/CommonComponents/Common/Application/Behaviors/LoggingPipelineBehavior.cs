namespace Common.Application.Behaviors;

/// <summary>
/// Logging pipeline behavior.
/// </summary>
/// <typeparam name="TRequest"> The request type.</typeparam>
/// <typeparam name="TResponse"> The response type.</typeparam>
/// <param name="logger"> The logger.</param>
public sealed class LoggingPipelineBehavior<TRequest, TResponse>
    (ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger = logger;

    /// <summary>
    /// Add to log the request and response.
    /// </summary>
    /// <param name="request"> The request.</param>
    /// <param name="next"> The next request.</param>
    /// <param name="cancellationToken"> The <see cref="CancellationToken"/>.</param>
    /// <returns></returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Handling {@RequestName}, {@DateTimeUtcNow}",
            typeof(TRequest).Name,
            DateTime.UtcNow);

        //get next request
        var response = await next();

        if(response.IsSuccess)
        {
            _logger.LogInformation(
                "Handled {@RequestName}, {@DateTimeUtcNow}",
                typeof(TRequest).Name,
                DateTime.UtcNow);

            return response;
        }

        _logger.LogError(
            "Handled {@RequestName}, {@Error} {@DateTimeUtcNow} error",
            typeof(TRequest).Name,
            response.Error,
            DateTime.UtcNow);

        return response;
    }
}
