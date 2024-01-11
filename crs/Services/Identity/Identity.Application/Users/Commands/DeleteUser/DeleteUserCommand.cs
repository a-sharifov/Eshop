namespace Identity.Application.Users.Commands.DeleteUser;

public sealed record DeleteUserCommand(Guid UserId) : ICommand;
