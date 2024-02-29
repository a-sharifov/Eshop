namespace Basket.Persistence.DbContexts;

public sealed class MongoDbContextOptions
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}