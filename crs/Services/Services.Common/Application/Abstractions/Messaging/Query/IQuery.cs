namespace Services.Common.Application.Abstractions.Messaging.Query;

public interface IQuery : IRequest<Result>
{
}

public interface IQuery<TQuery> : IRequest<Result<TQuery>>
{
}
