namespace Contracts.Services.Identity.Commands;

public sealed record UserCreatedConfirmationEmailSendCommand(
    Guid Id,
    Guid UserId,
    string returnUrl) : IntegrationCommand(Id);
