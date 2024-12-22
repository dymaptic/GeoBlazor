namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     Symbol is the abstract base class for all symbols. Symbols represent point, line, polygon, and mesh geometries as vector graphics within a View. Symbols can only be set directly on individual graphics in a GraphicsLayer or in View.graphics. Otherwise they are assigned to a Renderer that is applied to a Layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Symbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(SymbolJsonConverter))]
public abstract class Symbol : MapComponent
{
    /// <summary>
    ///     The color of the symbol.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? Color { get; set; }

    /// <summary>
    ///     The symbol type
    /// </summary>
    public virtual string Type => default!;

    internal abstract SymbolSerializationRecord ToSerializationRecord();
}

internal class SymbolJsonConverter : JsonConverter<Symbol>
{
    public override Symbol? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // deserialize based on the subclass type
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
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
                case "simple-marker":
                    return JsonSerializer.Deserialize<SimpleMarkerSymbol>(ref cloneReader, newOptions);
                case "simple-line":
                    return JsonSerializer.Deserialize<SimpleLineSymbol>(ref cloneReader, newOptions);
                case "simple-fill":
                    return JsonSerializer.Deserialize<SimpleFillSymbol>(ref cloneReader, newOptions);
                case "picture-marker":
                    return JsonSerializer.Deserialize<PictureMarkerSymbol>(ref cloneReader, newOptions);
                case "text":
                    return JsonSerializer.Deserialize<TextSymbol>(ref cloneReader, newOptions);
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, Symbol value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}

[ProtoContract(Name = "Symbol")]
internal record SymbolSerializationRecord : MapComponentSerializationRecord
{
    public SymbolSerializationRecord()
    {
    }
    
    public SymbolSerializationRecord(string Type,
        MapColor? Color)
    {
        this.Type = Type;
        this.Color = Color;
    }

    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public MapColor? Color { get; init; }
    
    [ProtoMember(3)]
    public SymbolSerializationRecord? Outline { get; init; }

    [ProtoMember(4)]
    public double? Size { get; init; }

    [ProtoMember(5)]
    public string? Style { get; init; }

    [ProtoMember(6)]
    public double? Angle { get; init; }

    [ProtoMember(7)]
    public double? XOffset { get; init; }

    [ProtoMember(8)]
    public double? YOffset { get; init; }

    [ProtoMember(9)]
    public double? Width { get; init; }

    [ProtoMember(10)]
    public string? LineStyle { get; init; }

    [ProtoMember(11)]
    public string? Text { get; init; }

    [ProtoMember(12)]
    public MapColor? HaloColor { get; init; }

    [ProtoMember(13)]
    public double? HaloSize { get; init; }

    [ProtoMember(14)]
    public MapFontSerializationRecord? MapFont { get; init; }

    [ProtoMember(15)]
    public double? Height { get; init; }

    [ProtoMember(16)]
    public string? Url { get; init; }
    
    [ProtoMember(17)]
    public MapColor? BackgroundColor { get; init; }
    
    [ProtoMember(18)]
    public double? BorderLineSize { get; init; }
    
    [ProtoMember(19)]
    public MapColor? BorderLineColor { get; init; }
    
    [ProtoMember(20)]
    public string? HorizontalAlignment { get; init; }
    
    [ProtoMember(21)]
    public bool? Kerning { get; init; }
    
    [ProtoMember(22)]
    public double? LineHeight { get; init; }
    
    [ProtoMember(23)]
    public double? LineWidth { get; init; }
    
    [ProtoMember(24)]
    public bool? Rotated { get; init; }
    
    [ProtoMember(25)]
    public string? VerticalAlignment { get; init; }
    
    [ProtoMember(26)]
    public double? XScale { get; init; }
    
    [ProtoMember(27)]
    public double? YScale { get; init; }

    public Symbol FromSerializationRecord(bool isOutline = false)
    {
        return Type switch
        {
            "outline" => new Outline(Color, Width, LineStyle is null ? null : Enum.Parse<LineStyle>(LineStyle!, true)),
            "simple-marker" => new SimpleMarkerSymbol(Outline?.FromSerializationRecord(true) as Outline, Color, Size, 
                Style is null ? null : Enum.Parse<SimpleMarkerStyle>(Style!, true), Angle, XOffset, YOffset),
            "simple-line" => isOutline 
                ? new Outline(Color, Width, LineStyle is null ? null : Enum.Parse<LineStyle>(LineStyle!, true))
                : new SimpleLineSymbol(Color, Width, LineStyle is null ? null : Enum.Parse<LineStyle>(LineStyle!, true)),
            "simple-fill" => new SimpleFillSymbol(Outline?.FromSerializationRecord(true) as Outline, Color, 
                Style is null ? null : Enum.Parse<FillStyle>(Style!, true)),
            "picture-marker" => new PictureMarkerSymbol(Url!, Width, Height, Angle, XOffset, YOffset),
            "picture-fill" => new PictureFillSymbol(Url!, Width, Height, XOffset, YOffset, XScale, YScale, 
                Outline?.FromSerializationRecord(true) as Outline),
            "text" => new TextSymbol(Text ?? string.Empty, Color, HaloColor, HaloSize, 
                MapFont?.FromSerializationRecord(), Angle, BackgroundColor, BorderLineColor,
                BorderLineSize, HorizontalAlignment is null ? null : Enum.Parse<HorizontalAlignment>(HorizontalAlignment!, true),
                Kerning, LineHeight, LineWidth, Rotated, 
                VerticalAlignment is null ? null : Enum.Parse<VerticalAlignment>(VerticalAlignment!, true),
                XOffset, YOffset),
            _ => throw new ArgumentException($"Unknown symbol type: {Type}")
        };
    }
}