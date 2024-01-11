namespace Identity.Application.Users.Commands.UpdateRefreshToken;

public sealed record UpdateRefreshTokenCommand(
    string Token,
    string RefreshToken,
    string Audience) 
    : ICommand<UpdateRefreshTokenCommandResponse>;
