namespace EventBus.MassTransit.RabbitMQ.Options;

public sealed class RabitMQOptions : IOptions
{
    public string Host { get; set; } = null!;
    public int Port { get; set; } = 5672;
    public string VirtualHost { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
