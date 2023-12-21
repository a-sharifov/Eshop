namespace Identity.Domain.AggregatesModel.UserAggregate.Ids;

public record UserId(Guid Value) : IStrongestId;
