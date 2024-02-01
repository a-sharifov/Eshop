namespace Common.Domain.Primitives;

/// <summary>
/// Abstract class for aggregate root.
/// </summary>
/// <typeparam name="StrongestId"> The strongest id type.</typeparam>
public class AggregateRoot<StrongestId> : Entity<StrongestId>
    where StrongestId : IStrongestId
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{StrongestId}"/> class.
    /// </summary>
    protected AggregateRoot() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{StrongestId}"/> class.
    /// </summary>
    /// <param name="id"> The id.</param>
    protected AggregateRoot(StrongestId id) : base(id) { }
}
