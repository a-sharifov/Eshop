namespace Identity.Domain.UserAggregate.Ids;

public record UserId(Guid Value) : IStrongestId;
