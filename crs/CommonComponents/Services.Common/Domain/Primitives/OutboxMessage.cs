namespace Services.Common.Domain.Primitives;

/// <summary>
/// Class for outbox message pattern.
/// </summary>
/// <param name="id"> The id of the message.</param>
/// <param name="createdAt"> The date and time when the message was created.</param>
/// <param name="type"> The type of the message.</param>
/// <param name="message"> The message.</param>
public class OutboxMessage(Guid id, DateTime createdAt, string type, string message)
{
    /// <summary>
    /// The id of the message.
    /// </summary>
    public Guid Id { get; private set; } = id;

    /// <summary>
    /// The date and time when the message was created.
    /// </summary>
    public DateTime CreatedAt { get; private set; } = createdAt;

    /// <summary>
    /// The type of the message.
    /// </summary>
    public string Type { get; private set; } = type;

    /// <summary>
    /// The message.
    /// </summary>
    public string Message { get; private set; } = message;

    /// <summary>
    /// The date and time when the message was processed.
    /// </summary>
    public DateTime? ProcessedAt { get; private set; }

    /// <summary>
    /// The error message.
    /// </summary>
    public string? Error { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the message is processed.
    /// </summary>
    public bool IsProcessed => ProcessedAt != null;

    /// <summary>
    /// Gets a value indicating whether the message is in progress.
    /// </summary>
    public bool InProgress => !IsProcessed;

    /// <summary>
    /// Mark the message as processed.
    /// </summary>
    public void Processed() => ProcessedAt = DateTime.UtcNow;

    /// <summary>
    /// Mark the message as in progress.
    /// </summary>
    /// <param name="error"> The error message.</param>
    public void ErrorOccured(string? error)
    {
        if (error.IsNullOrWhiteSpace())
        {
            return;
        }

        Error = error;
    }
}
