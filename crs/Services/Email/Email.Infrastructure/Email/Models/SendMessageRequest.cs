namespace Email.Infrastructure.Email.Models;

public record SendMessageRequest(
    string To,
    string Subject,
    string Body
    );
