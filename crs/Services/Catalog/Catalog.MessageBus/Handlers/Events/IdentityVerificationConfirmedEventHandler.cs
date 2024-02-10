namespace Catalog.MessageBus.Handlers.Events;

internal sealed class IdentityVerificationConfirmedEventHandler(ISender sender)
     : IntegrationEventHandler<IdentityVerificationConfirmedEvent>
{
    private readonly ISender _sender = sender;

    public override async Task Handle(ConsumeContext<IdentityVerificationConfirmedEvent> context)
    {
     
    }
}
