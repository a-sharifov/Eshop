namespace Common.Domain.Primitives;

/// <summary>
/// Interface for entity.
/// </summary>
/// <typeparam name="TId"> The id type.</typeparam>
public interface IEntity<TId>
{
    /// <summary>
    /// Gets the id of the entity.
    /// </summary>
    TId Id { get; }
}
