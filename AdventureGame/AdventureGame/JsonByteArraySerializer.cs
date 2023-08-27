using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class JsonIncludePrivateFieldsAttribute : Attribute { }

public static class JsonByteArraySerializer
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = GetJsonSerializerOptions();

    /// <summary>
    /// Convert an object to a Byte Array.
    /// </summary>
    public static byte[]? ObjectToByteArray(object objData)
    {
        if (objData == null)
            return default;

        return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(objData, _jsonSerializerOptions));
    }

    /// <summary>
    /// Convert a byte array to an Object of T.
    /// </summary>
    public static T? ByteArrayToObject<T>(byte[] byteArray)
    {
        if (byteArray == null || !byteArray.Any())
            return default;

        var json = Encoding.UTF8.GetString(byteArray);

        var test = JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions);

        return test;
    }

    private static JsonSerializerOptions GetJsonSerializerOptions()
    {
        return new JsonSerializerOptions() {
            TypeInfoResolver = new DefaultJsonTypeInfoResolver {
                Modifiers = { AddPrivateFieldsModifier }
            },
            PropertyNamingPolicy = null,
            WriteIndented = true,
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };
    }

    static void AddPrivateFieldsModifier(JsonTypeInfo jsonTypeInfo)
    {
        if (jsonTypeInfo.Kind != JsonTypeInfoKind.Object)
            return;

        if (!jsonTypeInfo.Type.IsDefined(typeof(JsonIncludePrivateFieldsAttribute), inherit: false))
            return;

        foreach (FieldInfo field in jsonTypeInfo.Type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
        {
            JsonPropertyInfo jsonPropertyInfo = jsonTypeInfo.CreateJsonPropertyInfo(field.FieldType, field.Name);
            jsonPropertyInfo.Get = field.GetValue;
            jsonPropertyInfo.Set = field.SetValue;

            jsonTypeInfo.Properties.Add(jsonPropertyInfo);
        }
    }
}