namespace Services.Common.Domain.Primitives;

public abstract class Entity<TStrongestId> 
    : IHasDomainEvents
    where TStrongestId : IStrongestId 
{
    public virtual TStrongestId Id { get; protected set; }

    private readonly List<IDomainEvent> _domainEvents;

    protected Entity() { }

    protected Entity(TStrongestId id) =>
       (Id, _domainEvents) = (id, new());


    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

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

        if(obj.GetType() != GetType())
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

    public void ClearDomainEvents() =>
        _domainEvents.Clear();
}
