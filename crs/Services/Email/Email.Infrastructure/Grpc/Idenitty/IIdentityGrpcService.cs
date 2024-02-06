namespace Email.Infrastructure.Grpc.Idenitty;

public interface IIdentityGrpcService
{
    public Task<UserInfo> GetUserInfoAsync(Guid id, CancellationToken cancellationToken = default);
}
