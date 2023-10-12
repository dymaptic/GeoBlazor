using Microsoft.AspNetCore.Components;
using ProtoBuf;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     The font used to display 2D text symbols and 3D text symbols. This class allows the developer to set the font's
///     family, decoration, size, style, and weight properties. Take note of the "Known Limitations" for each property to
///     understand how they differ depending on the layer type, and if you working with a MapView or SceneView.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Font.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[ProtoContract]
public class MapFont : MapComponent
{
    /// <summary>
    ///     The font size in points.
    /// </summary>
    [Parameter]
    [ProtoMember(1)]
    public int? Size { get; set; }

    /// <summary>
    ///     The font family of the text.
    /// </summary>
    [Parameter]
    [ProtoMember(2)]
    public string? Family { get; set; }

    /// <summary>
    ///     The text style.
    /// </summary>
    [Parameter]
    [JsonPropertyName("style")]
    [ProtoMember(3, Name = "style")]
    public string? FontStyle { get; set; }

    /// <summary>
    ///     The text weight.
    /// </summary>
    [Parameter]
    [ProtoMember(4)]
    public string? Weight { get; set; }

    internal MapFontSerializationRecord ToSerializationRecord()
    {
        return new MapFontSerializationRecord(Size, Family, FontStyle, Weight);
    }
}

internal record MapFontSerializationRecord([property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        int? Size,
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Family,
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Style,
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Weight)
    : MapComponentSerializationRecord;