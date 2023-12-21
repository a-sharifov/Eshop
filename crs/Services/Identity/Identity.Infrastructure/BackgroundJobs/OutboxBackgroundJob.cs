namespace Identity.Infrastructure.BackgroundJobs;

[DisallowConcurrentExecution]
public sealed class OutboxBackgroundJob(
    IdentityDbContext dbContext,
    IPublisher publisher)
    : IJob
{
    private readonly IdentityDbContext _dbContext = dbContext;
    private readonly IPublisher _publisher = publisher;
    private const int TakeLength = 100;
    private const int RetryCount = 2;

    public async Task Execute(IJobExecutionContext context)
    {
        var cancellationToken = context.CancellationToken;

        var messages = await _dbContext
            .Set<OutboxMessage>()
            .Where(message => message.ProcessedAt == null)
            .OrderBy(message => message.Id)
            .Take(TakeLength)
            .ToListAsync(cancellationToken);

        await PublishDomainEventsAsync(
            messages,
            cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task PublishDomainEventsAsync(
        List<OutboxMessage> messages,
        CancellationToken cancellationToken = default)
    {
        foreach (var message in messages)
        {
            await PublishDomainEventAsync(message, cancellationToken);
        }
    }

    private async Task PublishDomainEventAsync(OutboxMessage message, CancellationToken cancellationToken)
    {
        var domainEvent = JsonSerializer.DeserializeObject<IDomainEvent>(message.Message);

        if (domainEvent is null)
        {
            message.ErrorOccured("Deserialization failed");
            return;
        }

        var policy = Policy.Handle<Exception>()
            .RetryAsync(RetryCount);

        var result = await policy.ExecuteAndCaptureAsync(async () =>
        await _publisher.Publish(
        domainEvent,
        cancellationToken));

        message.ErrorOccured(
            result.FinalException?.ToString());

        message.Processed();
    }
}
