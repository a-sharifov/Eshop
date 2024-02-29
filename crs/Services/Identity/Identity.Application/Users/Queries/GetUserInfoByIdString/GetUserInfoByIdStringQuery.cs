namespace Identity.Application.Users.Queries.GetUserInfoByIdString;

public sealed record GetUserInfoByIdStringQuery(string Id) : IQuery<UserDto>;
