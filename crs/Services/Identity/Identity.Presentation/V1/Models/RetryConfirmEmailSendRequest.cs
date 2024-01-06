namespace Identity.Presentation.V1.Models;

public sealed record RetryConfirmEmailSendRequest([Required] Guid UserId);
