﻿namespace Services.Common.Serializers;

public class JsonSerializer
{
    private static JsonSerializerSettings GetSettings =>
       new JsonSerializerSettings
       {
           TypeNameHandling = TypeNameHandling.All,
           ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
       };

    public static string SerializeObject(object? obj) =>
        JsonConvert.SerializeObject(obj, GetSettings);

    public static T? DeserializeObject<T>(string json) =>
        JsonConvert.DeserializeObject<T>(json, GetSettings);
}