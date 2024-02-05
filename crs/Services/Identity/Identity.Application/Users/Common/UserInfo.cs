namespace Identity.Application.Users.Common;

public sealed record UserInfo(
    Guid UserId,
    string Email,
    string FirstName,
    string LastName,
    bool IsEmailConfirmed,
    string Role,
    string Gender);
