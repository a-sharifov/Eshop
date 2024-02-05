namespace EventBus.Common.Abstractions;

/// <summary>
/// The message interface.
/// </summary>
public interface IMessage
{
    /// <summary>
    /// The id message.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// The creation date of the message.
    /// </summary>
    DateTime CreatedAt { get; }
}
