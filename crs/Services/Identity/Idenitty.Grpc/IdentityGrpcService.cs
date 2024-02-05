namespace Idenitty.Grpc;

public sealed class IdentityGrpcService(ISender sender) : IdentityService.IdentityServiceBase
{
    private readonly ISender _sender = sender;

    public override async Task<User> GetUser(GetUserRequest request, ServerCallContext context)
    {
        var result = await _sender.Send();

        return base.GetUser(request, context);
    }
}
