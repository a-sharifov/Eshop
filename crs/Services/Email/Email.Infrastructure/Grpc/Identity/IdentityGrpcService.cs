using static Identity.Protobuf.IdentityService;

namespace Email.Infrastructure.Grpc.Identity;

internal sealed class IdentityGrpcService(IdentityServiceClient client) : IIdentityGrpcService
{
    private readonly IdentityServiceClient _client = client;

    public async Task<UserInfo> GetUserInfoAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var request = new GetUserRequest() { Id = id.ToString() };
        return await _client.GetUserInfoAsync(request, cancellationToken: cancellationToken);
    }
}
