namespace Identity.Persistence;

public sealed class UserDbContext(DbContextOptions<UserDbContext> options)
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
            .ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
