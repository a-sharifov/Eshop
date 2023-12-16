namespace Catalog.Persistence;

public sealed class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
{
    // CatalogDbContext
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Product> Products { get; set; }

    //Outbox pattern
    public DbSet<OutboxMessage> outboxMessages { get; set; }
    public DbSet<OutboxMessageConsumer> outboxMessageConsumers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<IList<IDomainEvent>>()
                    .ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
    }
}
