namespace Catalog.Infrastructure.Grpc.Identity;

public interface IIdentityGrpcService
{
    public Task<UserInfo> GetUserInfoAsync(Guid id, CancellationToken cancellationToken = default);
}
