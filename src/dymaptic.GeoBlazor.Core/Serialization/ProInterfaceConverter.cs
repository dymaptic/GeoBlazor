namespace dymaptic.GeoBlazor.Core.Serialization;

public class ProInterfaceConverter<T> : JsonConverter<T> where T: IProComponent
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        isPro ??= Licensing.GetLicenseType() == LicenseType.Pro;

        if (!isPro.Value)
        {
            return default;
        }
        
        proTypes ??= Assembly.Load("dymaptic.GeoBlazor.Pro").GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IProComponent)))
            .ToArray();
        
        // the name should be the same as the interface name without the I prefix
        Type? proType = proTypes.FirstOrDefault(t => t.Name == typeof(T).Name.Substring(1));

        if (proType != null)
        {
            // Deserialize using the Pro type
            return (T?)JsonSerializer.Deserialize(ref reader, proType, options);
        }

        // Return null if the Pro type is not available
        return default;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        isPro ??= Licensing.GetLicenseType() == LicenseType.Pro;
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), GeoBlazorSerialization.JsonSerializerOptions));
    }

    private static bool? isPro;
    private static Type[]? proTypes;
}