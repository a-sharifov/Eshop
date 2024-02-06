using Identity.Application.Users.Queries.GetUserInfoByIdString;
using Identity.Protobuf;

namespace Idenitty.Grpc;

public sealed class IdentityGrpcServiceV1(ISender sender) : IdentityService.IdentityServiceBase
{
    private readonly ISender _sender = sender;

    public override async Task<UserInfo> GetUserInfo(GetUserRequest request, ServerCallContext context)
    {
        var query = new GetUserInfoByIdStringQuery(request.Id);
        var result = await _sender.Send(query, context.CancellationToken);

        if (result.IsFailure)
        {
            throw new RpcException(new Status(StatusCode.NotFound, result.Error));
        }

        var user = result.Value;

        var response = new UserInfo()
        {
            UserId = user.UserId.ToString(),
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            IsEmailConfirmed = user.IsEmailConfirmed,
            Role = Enum.Parse<Role>(user.Role),
            Gender = Enum.Parse<Gender>(user.Gender)
        };

        return response;
    }
}
