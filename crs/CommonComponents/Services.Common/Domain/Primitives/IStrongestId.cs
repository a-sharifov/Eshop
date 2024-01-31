namespace Services.Common.Domain.Primitives;

/// <summary>
/// Interface for strongest id.
/// </summary>
public interface IStrongestId  
{
    /// <summary>
    /// Gets the value of the id.
    /// </summary>
    Guid Value { get; }
}
