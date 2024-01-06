namespace Identity.Application.Users.Commands.UpdateRefreshToken;

public sealed record UpdateRefreshTokenCommandResponse(
    string Token,
    string RefreshToken);
