namespace Common.Domain.Primitives;

public abstract class Enumeration<TEnum>(
    int value, 
    string name)

    where TEnum : Enumeration<TEnum>
{
    public readonly int Value = value;
    public readonly string Name = name;
    private static readonly Dictionary<int, TEnum> _enumerations = GetEnumerations();


    public static TEnum? FromValue(int value) =>
        _enumerations.TryGetValue(value, out var enumeration) 
        ? enumeration : null;

    public static TEnum? FromName(string name) =>
        _enumerations.Values.SingleOrDefault(x => x.Name == name);

    private static Dictionary<int, TEnum> GetEnumerations()
    {
        var enumerationType = typeof(TEnum);

        var fields = enumerationType.GetFields(
            BindingFlags.Public | 
            BindingFlags.Static | 
            BindingFlags.DeclaredOnly)
            .Where(fieldInfo => enumerationType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo => (TEnum)fieldInfo.GetValue(default)!);

        return fields.ToDictionary(field => field.Value);
    }

}
