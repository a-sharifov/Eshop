namespace Services.Common.Application.Abstractions.Messaging.Command;

/// <summary>
/// Interface for command - CQRS.
/// </summary>
public interface ICommand : IRequest<Result>
{
}

/// <summary>
/// Interface for command with a response - CQRS.
/// </summary>
/// <typeparam name="TResponse"> The response type.</typeparam>
public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
