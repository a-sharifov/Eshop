namespace Email.Infrastructure.Email.Models;

public record SendConfirmationEmailRequest(
    string FirstName,
    string LastName,
    string Email,
    string EmailConfirmationToken,
    string ReturnUrl,
    string EmailConfirmPagePath
    );
