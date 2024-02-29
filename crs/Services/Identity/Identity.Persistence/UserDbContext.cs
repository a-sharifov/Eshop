namespace Identity.Persistence;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    //IdentityDbContext
    public DbSet<User> Users { get; set; }

    //Outbox pattern
    public DbSet<OutboxMessage> OutboxMessages { get; set; } 
    public DbSet<OutboxMessageConsumer> OutboxMessageConsumers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<IList<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
