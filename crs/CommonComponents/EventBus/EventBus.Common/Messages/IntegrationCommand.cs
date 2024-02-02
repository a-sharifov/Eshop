namespace EventBus.Common.Messages;

/// <summary>
/// The command.
/// </summary>
/// <param name="Id">The identifier command.</param>
public abstract record IntegrationCommand(Guid Id) : IIntegrationCommand
{
    /// <summary>
    /// The creation date of the command.
    /// </summary>
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
