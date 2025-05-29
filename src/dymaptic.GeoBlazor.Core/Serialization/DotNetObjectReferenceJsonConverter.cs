namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Custom converter to ensure that end users can serialize things like Graphics without getting hit by a loop with the `DotNetComponentReference` property that causes a Stack Overflow.
/// </summary>
internal class DotNetObjectReferenceJsonConverter : JsonConverter<DotNetObjectReference<MapComponent>>
{
    public override DotNetObjectReference<MapComponent>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize(ref reader, typeToConvert, options) as DotNetObjectReference<MapComponent>;
    }

    public override void Write(Utf8JsonWriter writer, DotNetObjectReference<MapComponent> value, JsonSerializerOptions options)
    {
        // Using for loop for performance since this is hit a lot. Looking at the JsRuntime source, it would be possible right
        // now to know that the _first_ converter can handle this type, but that could change in the future.
        // ReSharper disable once ForCanBeConvertedToForeach
        // ReSharper disable once LoopCanBeConvertedToQuery
        for (int i = 0; i < options.Converters.Count; i++)
        {
            if (options.Converters[i].CanConvert(typeof(DotNetObjectReference<MapComponent>)))
            {
                JsonSerializer.Serialize(writer, value, options);
                return;
            }
        }
        
        writer.WriteNullValue();
    }
}