using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     The font used to display 2D text symbols and 3D text symbols. This class allows the developer to set the font's
///     family, decoration, size, style, and weight properties. Take note of the "Known Limitations" for each property to
///     understand how they differ depending on the layer type, and if you working with a MapView or SceneView.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Font.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class MapFont : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public MapFont()
    {
    }
    
    /// <summary>
    ///     Constructs a new MapFont in code with parameters
    /// </summary>
    /// <param name="size">
    ///     The font size in points.
    /// </param>
    /// <param name="family">
    ///     The font family of the text.
    /// </param>
    /// <param name="style">
    ///     The text style.
    /// </param>
    /// <param name="weight">
    ///     The text weight.
    /// </param>
    public MapFont(Dimension? size, string? family, string? style, string? weight)
    {
#pragma warning disable BL0005
        Size = size;
        Family = family;
        FontStyle = style;
        Weight = weight;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     The font size in points. This value may be autocast with a string expressing size in points or pixels (e.g. 12px).
    /// </summary>
    [Parameter]
    [ProtoMember(1)]
    public Dimension? Size { get; set; }

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
        return new MapFontSerializationRecord(Size?.Points, Family, FontStyle, Weight);
    }
}

[ProtoContract]
internal record MapFontSerializationRecord
{
    public MapFontSerializationRecord()
    {
    }
    
    public MapFontSerializationRecord(double? Size, string? Family, string? FontStyle, string? Weight)
    {
        this.Size = Size;
        this.Family = Family;
        this.FontStyle = FontStyle;
        this.Weight = Weight;
    }

    [ProtoMember(1)]
    public double? Size { get; init; }
    
    [ProtoMember(2)]
    public string? Family { get; init; }
    
    [ProtoMember(3)]
    public string? FontStyle { get; init; }
    
    [ProtoMember(4)]
    public string? Weight { get; init; }
    
    public MapFont FromSerializationRecord()
    {
        return new MapFont(Size, Family, FontStyle, Weight);
    }
}