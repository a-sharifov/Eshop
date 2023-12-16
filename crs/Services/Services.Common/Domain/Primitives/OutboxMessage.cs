namespace Services.Common.Domain.Primitives;

public class OutboxMessage(Guid id, DateTime createdAt, string type, string message)
{
    public Guid Id { get; private set; } = id;
    public DateTime CreatedAt { get; private set; } = createdAt;
    public string Type { get; private set; } = type;
    public string Message { get; private set; } = message;
    public DateTime? ProcessedAt { get; private set; }
    public string? Error { get; private set; }

    public bool IsProcessed => ProcessedAt != null;
    public bool InProgress => !IsProcessed;

    public void Processed() => ProcessedAt = DateTime.UtcNow;

    public void ErrorOccured(string? error)
    {
        if (string.IsNullOrWhiteSpace(error))
        {
            return;
        }

        Error = error;
    }
}
