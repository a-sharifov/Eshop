using Catalog.Application.Sellers.Commands.AddSeller;

namespace Catalog.MessageBus.Handlers.Events;

internal sealed class IdentityVerificationConfirmedEventHandler(ISender sender)
     : IntegrationEventHandler<IdentityVerificationConfirmedEvent>
{
    private readonly ISender _sender = sender;

    public override async Task Handle(ConsumeContext<IdentityVerificationConfirmedEvent> context)
    {
        var command = new AddSellerCommand(context.Message.UserId);

        await _sender.Send(command);
    }
}
