namespace Services.Common.Domain.Primitives;

public class AggregateRoot<StrongestId> : Entity<StrongestId>
    where StrongestId : IStrongestId
{
    protected AggregateRoot() { }

    protected AggregateRoot(StrongestId id) : base(id) { }
}
