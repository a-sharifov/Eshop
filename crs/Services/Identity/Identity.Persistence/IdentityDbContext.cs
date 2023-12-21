namespace Identity.Persistence;

public sealed class IdentityDbContext(DbContextOptions<IdentityDbContext> options) 
    : DbContext(options)
{
    //IdentityDbContext
    public DbSet<User> Users { get; set; }

    //Outbox pattern
    public DbSet<OutboxMessage> OutboxMessages { get; set; } 
    public DbSet<OutboxMessageConsumer> outboxMessageConsumers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<IList<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}
