namespace Identity.Application.Users.Commands.UpdateRefreshToken;

public sealed record UpdateRefreshTokenCommand(
    string Token,
    string RefreshToken) 
    : ICommand<UpdateRefreshTokenCommandResponse>;
