namespace Basket.Persistence.DbContexts.Abstractions;

public interface IMongoDbContext
{
    void AddCommand(Func<Task> func);
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
      IMongoCollection<T> GetCollection<T>(string name);
}