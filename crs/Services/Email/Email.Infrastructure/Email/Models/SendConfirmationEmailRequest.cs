namespace Email.Infrastructure.Email.Models;

public record SendConfirmationEmailRequest(
    string FirstName,
    string LastName,
    string UserId,
    string Email,
    string EmailConfirmationToken,
    string ReturnUrl
    );
