namespace Services.Common.Domain.Primitives;

/// <summary>
/// Interface for repository.
/// </summary>
/// <typeparam name="TEntity"> The entity type.</typeparam>
/// <typeparam name="TStrongestId"> The strongest id type.</typeparam>
public interface IRepository<TEntity, TStrongestId>
    where TEntity : Entity<TStrongestId>
    where TStrongestId : IStrongestId
{
}
