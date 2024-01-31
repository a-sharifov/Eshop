namespace Services.Common.Application.Behaviors;

/// <summary>
/// Validation pipeline behavior.
/// </summary>
/// <typeparam name="TRequest"> The request type.</typeparam>
/// <typeparam name="TResponse"> The response type.</typeparam>
/// <param name="validators"> The validators.</param>
public sealed class ValidationPipelineBehavior<TRequest, TResponse>
    (IEnumerable<IValidator<TRequest>> validators) 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    /// <summary>
    /// The validators.
    /// </summary>
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    /// <summary>
    /// Add to validate the request.
    /// </summary>
    /// <param name="request"> The request.</param>
    /// <param name="next"> The next request.</param>
    /// <param name="cancellationToken"> The <see cref="CancellationToken"/>.</param>
    /// <returns></returns>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        //if no validators, return next
        if (!_validators.Any())
        {
            return await next();
        }

        var errors = GetErrors(request);

        //if errors, return validation result
        if (errors.Any())
        {
            return CreateValidationResult<TResponse>(errors);
        }
        
        //else return next
        return await next();
    }

    /// <summary>
    /// Get errors from validators.
    /// </summary>
    /// <param name="request"> The request.</param>
    /// <returns> The errors.</returns>
    private Error[] GetErrors(TRequest request) =>
        _validators.Select(
            validator => validator.Validate(request))
        .SelectMany(result => result.Errors)
        .Select(failure => new Error(
            failure.PropertyName, 
            failure.ErrorMessage))
        .Distinct()
        .ToArray();


    /// <summary>
    /// Create validation result.
    /// if TResult is Result, return ValidationResult
    /// else return ValidationResult of TResult
    /// </summary>
    /// <typeparam name="TResult"> The result type.</typeparam>
    /// <param name="errors"> The errors.</param>
    /// <returns> The validation result.</returns>
    private static TResult CreateValidationResult<TResult>(Error[] errors)
        where TResult : Result
    {
        if(typeof(TResult) == typeof(Result))
        {
            return (ValidationResult.WithErrors(errors) as TResult)!;
        }

        var validationResult = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
            .GetMethod(nameof(ValidationResult.WithErrors))!
            .Invoke(null, new object[] { errors })!;

        return (TResult)validationResult;
    }
}
