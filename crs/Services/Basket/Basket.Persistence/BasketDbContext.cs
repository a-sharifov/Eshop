namespace Basket.Persistence;

internal sealed class BasketDbContext(DbContextOptions<BasketDbContext> options) : DbContext(options)
{
    // BasketDbContext
    public DbSet<CatalogBasket> Baskets { get; set; }
    public DbSet<CatalogBasketItem> BasketItems { get; set; }

    // Outbox pattern
    public DbSet<OutboxMessage> OutboxMessages { get; set; }
    public DbSet<OutboxMessageConsumer> OutboxMessageConsumers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<IList<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        modelBuilder.Entity<CatalogBasket>();
        modelBuilder.Entity<CatalogBasketItem>();
        modelBuilder.Entity<OutboxMessage>();
        modelBuilder.Entity<OutboxMessageConsumer>();
    }
}
