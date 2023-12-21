namespace Services.Common.Domain.Primitives;

public interface IEntity<TId>
{
    public TId Id { get; }
}
