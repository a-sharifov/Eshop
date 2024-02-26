namespace Common.Domain.Primitives;

/// <summary>
/// Abstract class for entity.
/// </summary>
/// <typeparam name="TStrongestId"></typeparam>
public abstract class Entity<TStrongestId> 
    : IEntity<TStrongestId>,
    IHasDomainEvents
    where TStrongestId : IStrongestId 
{
    /// <summary>
    /// Gets the id of the entity.
    /// </summary>
    public virtual TStrongestId Id { get; protected set; }

    /// <summary>
    /// Gets the domain events.
    /// </summary>
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TStrongestId}"/> class.
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Entity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TStrongestId}"/> class.
    /// </summary>
    /// <param name="id"> The id of the entity.</param>
    protected Entity(TStrongestId id) => Id = id;

    /// <summary>
    /// Gets the domain events.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Add a domain event.
    /// </summary>
    /// <param name="domainEvent"> The domain event.</param>
    protected void AddDomainEvent(IDomainEvent domainEvent) =>
       _domainEvents.Add(domainEvent);

    public static bool operator ==(Entity<TStrongestId>? left, Entity<TStrongestId>? right) =>
        left != null && left.Equals(right);

    public static bool operator !=(Entity<TStrongestId>? left, Entity<TStrongestId>? right) =>
        !(left == right);

    public override bool Equals(object? obj)
    {
        if(obj == null)
        {
            return false;
        }

        if(obj is not Entity<TStrongestId> entity)
        {
            return false;
        }

        return entity.Id.Value == Id.Value;
    }

    public override int GetHashCode() =>
        Id.GetHashCode();

    /// <summary>
    /// Clear the domain events.
    /// </summary>
    public void ClearDomainEvents() =>
        _domainEvents.Clear();
}
