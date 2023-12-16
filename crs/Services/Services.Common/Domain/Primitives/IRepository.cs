namespace Services.Common.Domain.Primitives;

public interface IRepository<TEntity, TStrongestId>
    where TEntity : Entity<TStrongestId>
    where TStrongestId : IStrongestId
{
}
