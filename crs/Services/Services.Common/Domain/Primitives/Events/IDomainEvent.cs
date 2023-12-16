namespace Services.Common.Domain.Primitives.Events;

public interface IDomainEvent : INotification
{
    public Guid Id { get; }
}
