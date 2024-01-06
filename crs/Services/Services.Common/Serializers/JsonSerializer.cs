namespace Services.Common.Serializers;

/// <summary>
/// Class for json serializer.
/// </summary>
public sealed class JsonSerializer
{
    /// <summary>
    /// Gets the settings.
    /// </summary>
    private static JsonSerializerSettings GetSettings =>
       new JsonSerializerSettings
       {
           TypeNameHandling = TypeNameHandling.All,
           //constructorHandling: Specifies how constructors
           //are used when initializing objects during deserialization by the JsonSerializer.
           ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
           ContractResolver = new PrivateSetterAndCtorContractResolver(),
       };


    /// <summary>
    /// Serialize an object.
    /// </summary>
    /// <param name="obj"> The object.</param>
    /// <returns> The json string.</returns>
    public static string SerializeObject(object? obj) =>
        JsonConvert.SerializeObject(obj, GetSettings);

    /// <summary>
    /// Deserialize an object.
    /// </summary>
    /// <typeparam name="T"> The type.</typeparam>
    /// <param name="json"> The json string.</param>
    /// <returns> The object.</returns>
    public static T? DeserializeObject<T>(string json) =>
        JsonConvert.DeserializeObject<T>(json, GetSettings);
}
