namespace Identity.Persistence;

public class UserDbContext : DbContext
{
    //IdentityDbContext
    public DbSet<User> Users { get; set; }

    //Outbox pattern
    public DbSet<OutboxMessage> OutboxMessages { get; set; } 
    public DbSet<OutboxMessageConsumer> OutboxMessageConsumers { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public UserDbContext() : base()
    {
        //For migrations
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<IList<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
