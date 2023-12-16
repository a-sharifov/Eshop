namespace Services.Common.Domain.Primitives;

public sealed record OutboxMessageConsumer(Guid Id, string Name);
