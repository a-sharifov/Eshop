using Identity.Application.Users.Queries.GetUserInfoById;
using Identity.V1;

namespace Idenitty.Grpc;

public sealed class IdentityGrpcServiceV1(ISender sender) : IdentityService.IdentityServiceBase
{
    private readonly ISender _sender = sender;

    public override async Task<UserInfo> GetUserInfo(GetUserRequest request, ServerCallContext context)
    {
        Guid.TryParse(request.Id, out Guid userId);

        //if(userId == Guid.Empty)
        //{
        //    context.Status = new Status(StatusCode.InvalidArgument, "Invalid user id");
        //}

        var query = new GetUserInfoByIdQuery(userId);
        var result = await _sender.Send(query);
        var response = new UserInfo() { s};
        return base.GetUser(request, context);
    }
}
