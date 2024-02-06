namespace Identity.Application.Users.Queries.GetUserInfoById;

public sealed record GetUserInfoByIdQuery(Guid Id) : IQuery<UserDto>;

