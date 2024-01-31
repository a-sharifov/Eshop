namespace Services.Common.Domain.Primitives;

/// <summary>
/// Abstract class for value object.
/// </summary>
public abstract class ValueObject :  IEquatable<ValueObject> 
{
    /// <summary>
    /// Gets the equality components.
    /// </summary>
    /// <returns> The equality components.</returns>
    public abstract IEnumerable<object> GetEqualityComponents();

    /// <summary>
    /// Equals the specified other.
    /// </summary>
    /// <param name="other"> The other value object.</param>
    /// <returns> The result of the equality.</returns>
    public bool Equals(ValueObject? other) =>
        other is not null && ValuesAreEqual(other);

    /// <summary>
    /// Equals the specified object.
    /// </summary>
    /// <param name="obj"> The object.</param>
    /// <returns> The result of the equality.</returns>
    public override bool Equals(object? obj) =>
        obj is ValueObject other && ValuesAreEqual(other);

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns> The hash code.</returns>
    public override int GetHashCode() =>
        GetEqualityComponents()
        .Aggregate(default(int), HashCode.Combine);

    /// <summary>
    /// Values are equal.
    /// </summary>
    /// <param name="other"> The other value object.</param>
    /// <returns> The result of the equality.</returns>
    private bool ValuesAreEqual(ValueObject other) =>
        GetEqualityComponents()
        .SequenceEqual(
            other.GetEqualityComponents());

    /// <summary>
    /// Equals operator.
    /// </summary>
    /// <param name="left"> The left value object.</param>
    /// <param name="right"> The right value object.</param>
    /// <returns> The result of the equality.</returns>
    public static bool operator ==(ValueObject? left, ValueObject? right) =>
        Equals(left, right);

    /// <summary>
    /// Not equals operator.
    /// </summary>
    /// <param name="left"> The left value object.</param>
    /// <param name="right"> The right value object.</param>
    /// <returns> The result of the equality.</returns>
    public static bool operator !=(ValueObject? left, ValueObject? right) =>
        !Equals(left, right);
}
