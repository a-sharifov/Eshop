namespace Common.Domain.Primitives;

/// <summary>
/// Interface for pattern unit of work.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Gets the database context.
    /// </summary>
    /// <param name="cancellationToken"> The <see cref="CancellationToken" />.</param>
    /// <returns> A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}
