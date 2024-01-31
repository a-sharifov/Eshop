namespace Services.Common.Application.Abstractions.Messaging.Query;

/// <summary>
/// Interface for query handlers - CQRS.
/// </summary>
public interface IQuery : IRequest<Result>
{
}

/// <summary>
/// Interface for query handlers with a response - CQRS.
/// </summary>
/// <typeparam name="TQuery"> The query type.</typeparam>
public interface IQuery<TQuery> : IRequest<Result<TQuery>>
{
}
