namespace Identity.Presentation.V1.Models;

public sealed record ConfirmEmailRequest(
    [Required] Guid UserId,
    [Required] string EmailConfirmationToken,
    [Required] string returnUrl);
