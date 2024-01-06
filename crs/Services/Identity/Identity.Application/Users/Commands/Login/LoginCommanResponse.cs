namespace Identity.Application.Users.Commands.Login;

public sealed record LoginCommanResponse(
    string Token,
    string RefreshToken);
