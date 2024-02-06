namespace Identity.Application.Users.Common;

public sealed record UserDto(
    Guid UserId,
    string Email,
    string FirstName,
    string LastName,
    bool IsEmailConfirmed,
    string Role,
    string Gender);