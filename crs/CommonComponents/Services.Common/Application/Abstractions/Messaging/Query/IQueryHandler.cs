namespace Services.Common.Application.Abstractions.Messaging.Query;

/// <summary>
/// Interface for query handlers - CQRS.
/// </summary>
/// <typeparam name="TQuery"> The query type.</typeparam>
/// <typeparam name="TResponse"> The response type.</typeparam>
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
