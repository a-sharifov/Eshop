namespace Catalog.Persistence.Services.Interfaces;

public interface ICachedBaseService
{
    public Task DeleteAsync(string key, CancellationToken cancellationToken = default);
    public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);
    public Task RefreshAsync(string key, CancellationToken cancellationToken = default);
    public Task SetAsync<T>(string key, T value, TimeSpan expirationTime = default, CancellationToken cancellationToken = default);
}
