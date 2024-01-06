namespace Catalog.Persistence.Services.Interfaces;

public interface ICachedBaseService
{
    Task DeleteAsync(string key, CancellationToken cancellationToken = default);
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);
    Task RefreshAsync(string key, CancellationToken cancellationToken = default);
    Task SetAsync<T>(string key, T value, TimeSpan expirationTime = default, CancellationToken cancellationToken = default);
}
