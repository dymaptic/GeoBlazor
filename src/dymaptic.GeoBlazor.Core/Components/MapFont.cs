namespace dymaptic.GeoBlazor.Core.Components;

public partial class MapFont : MapComponent, IProtobufSerializable
{


    /// <summary>
    ///     The text decoration.
    ///     default none
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Font.html#decoration">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TextDecoration? Decoration { get; set; }

    /// <summary>
    ///     The font size in points. This value may be autocast with a string expressing size in points or pixels (e.g. 12px).
    /// </summary>
    [Parameter]
    public Dimension? Size { get; set; }

    /// <summary>
    ///     The font family of the text.
    /// </summary>
    [Parameter]
    public string? Family { get; set; }

    /// <summary>
    ///     The text style.
    ///     default normal
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Font.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapFontStyle? Style { get; set; }

    /// <summary>
    ///     The text weight.
    ///     default normal
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Font.html#weight">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public FontWeight? Weight { get; set; }

    internal MapFontSerializationRecord ToSerializationRecord()
    {
        return new MapFontSerializationRecord(Id.ToString(), Size?.Points, Family, Style?.ToString().ToKebabCase(), 
            Weight?.ToString().ToKebabCase(), Decoration?.ToString().ToKebabCase());
    }
    
    public MapComponentSerializationRecord ToProtobuf()
    {
        return ToSerializationRecord();
    }
}

[ProtoContract]
internal record MapFontSerializationRecord: MapComponentSerializationRecord
{
    public MapFontSerializationRecord()
    {
    }

    public MapFontSerializationRecord(string Id, double? Size, string? Family, string? FontStyle, string? Weight, 
        string? Decoration)
    {
        this.Id = Id;
        this.Size = Size;
        this.Family = Family;
        this.FontStyle = FontStyle;
        this.Weight = Weight;
        this.Decoration = Decoration;
    }

    [ProtoMember(1)]
    public double? Size { get; init; }

    [ProtoMember(2)]
    public string? Family { get; init; }

    [ProtoMember(3)]
    public string? FontStyle { get; init; }

    [ProtoMember(4)]
    public string? Weight { get; init; }

    [ProtoMember(5)]
    public string? Decoration { get; init; }
    
    [ProtoMember(6)]
    public string? Id { get; init; }

    public MapFont FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guid))
        {
            id = guid;
        }
        return new MapFont(Size, Family, FontStyle is null ? null : Enum.Parse<MapFontStyle>(FontStyle), 
            Weight is null ? null : Enum.Parse<FontWeight>(Weight), 
            Decoration is null ? null : Enum.Parse<TextDecoration>(Decoration)) { Id = id };
    }
}