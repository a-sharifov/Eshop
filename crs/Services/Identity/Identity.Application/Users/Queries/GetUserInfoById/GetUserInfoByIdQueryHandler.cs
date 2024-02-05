namespace Identity.Application.Users.Queries.GetUserInfoById;

internal sealed class GetUserInfoByIdQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUserInfoByIdQuery, UserInfo>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<UserInfo>> Handle(GetUserInfoByIdQuery request, CancellationToken cancellationToken)
    {
        var userId = new UserId(request.Id);

        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<UserInfo>(
                UserErrors.UserDoesNotExist);
        }

        var userInfo = new UserInfo(
            user.Id, 
            user.Email.Value, 
            user.(r => r.Name).ToList());

        return Result.Success(userInfo);
    }
}
