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