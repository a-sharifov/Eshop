namespace Common.Domain.Primitives;

/// <summary>
/// Abstract class for aggregate root.
/// </summary>
/// <typeparam name="TStrongestId"> The strongest id type.</typeparam>
public abstract class AggregateRoot<TStrongestId> : Entity<TStrongestId>
    where TStrongestId : IStrongestId
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{StrongestId}"/> class.
    /// </summary>
    protected AggregateRoot() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="AggregateRoot{StrongestId}"/> class.
    /// </summary>
    /// <param name="id"> The id.</param>
    protected AggregateRoot(TStrongestId id) : base(id) { }
}
