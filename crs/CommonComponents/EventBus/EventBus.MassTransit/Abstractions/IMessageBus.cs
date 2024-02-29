namespace EventBus.MassTransit.Abstractions;

/// <summary>
/// The message bus interface.
/// </summary>
public interface IMessageBus : IMessageBusBase
{
    /// <summary>
    /// Get send endpoint by address.
    /// </summary>
    /// <param name="address"> The address.</param>
    /// <returns> The <see cref="ISendEndpoint"/>.</returns>
    Task<ISendEndpoint> GetSendEndpoint(Uri address);
}
