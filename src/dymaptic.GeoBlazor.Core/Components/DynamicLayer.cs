namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Abstract base class for <see cref="DynamicMapLayer"/> and <see cref="DynamicDataLayer"/>.
/// </summary>
[JsonConverter(typeof(DynamicLayerConverter))]
public abstract class DynamicLayer : MapComponent
{
    /// <summary>
    ///     The type of dynamic layer
    /// </summary>
    public abstract string Type { get; }
}


/// <summary>
///     Abstract base class for data sources in a dynamic data layer.
/// </summary>
[JsonConverter(typeof(DynamicDataSourceConverter))]
public abstract class DynamicDataSource : MapComponent
{
    /// <summary>
    ///     The name of the data source type.
    /// </summary>
    public abstract DynamicDataSourceType Type { get; }
}


internal class DynamicLayerConverter : JsonConverter<DynamicLayer>
{
    public override DynamicLayer? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        Utf8JsonReader cloneReader = reader;

        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, newOptions) is not
            IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.TryGetValue("type", out object? typeValue))
        {
            switch (typeValue?.ToString())
            {
                case "map-layer":
                    return JsonSerializer.Deserialize<DynamicMapLayer>(ref cloneReader, newOptions);
                case "data-layer":
                    return JsonSerializer.Deserialize<DynamicDataLayer>(ref cloneReader, newOptions);
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, DynamicLayer value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, typeof(object), options);
    }
}

internal class DynamicDataSourceConverter : JsonConverter<DynamicDataSource>
{
    public override DynamicDataSource? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        Utf8JsonReader cloneReader = reader;

        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, newOptions) is not
            IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.TryGetValue("type", out object? typeValue))
        {
            switch (typeValue?.ToString())
            {
                case "table":
                    return JsonSerializer.Deserialize<TableDataSource>(ref cloneReader, newOptions);
                case "query-table":
                    return JsonSerializer.Deserialize<QueryTableDataSource>(ref cloneReader, newOptions);
                case "raster":
                    return JsonSerializer.Deserialize<RasterDataSource>(ref cloneReader, newOptions);
                case "join-table":
                    return JsonSerializer.Deserialize<JoinTableDataSource>(ref cloneReader, newOptions);
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, DynamicDataSource value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, typeof(object), options);
    }
}