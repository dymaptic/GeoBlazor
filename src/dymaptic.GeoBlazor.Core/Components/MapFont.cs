namespace dymaptic.GeoBlazor.Core.Components;
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
    ///     Constructor for use in C# code.
    /// </summary>
    /// <param name = "size">
    ///     The font size in points.
    ///     default 9
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Font.html#size">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name = "family">
    ///     The font family of the text.
    ///     default sans-serif
    ///     The font family of the text. The possible values are dependent upon the layer type, and if you are working with a [MapView](https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html) or a [SceneView](https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html). See the [Labeling guide page](https://developers.arcgis.com/javascript/latest/labeling/) for detailed explanation, or click the `Read more` below.  >>> esri-read-more Font families for 3D SceneViews  The supported font families for 3D [SceneViews](https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html) are dependent upon the fonts installed on the user's computer and web browser. If an app uses a font that is not installed, the Font class implements a fallback mechanism that will use the default font family value, which is `sans-serif`. See these references for instructions on how to install a new font on [Windows](https://support.microsoft.com/en-us/help/314960/how-to-install-or-remove-a-font-in-windows) or [Mac](https://support.apple.com/en-us/ht201749).  Fonts that are not installed locally can also be loaded from a url by defining a [font-face](https://developer.mozilla.org/en-US/docs/Web/CSS/font-face) in a css file and referencing it from the `family` property in a symbol layer.  Font families for 2D MapImageLayer  The supported font families for [MapImageLayers](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-MapImageLayer.html) in a [MapView](https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html) are dependent upon the fonts installed on the [ArcGIS Server](https://enterprise.arcgis.com/en/server/latest/get-started/windows/what-is-arcgis-for-server-.htm) that published the layer. If an app uses a font that is not installed, the Font class implements a fallback mechanism that will use the default font family value, which is `sans-serif`.  Font families for 2D FeatureLayer, CSVLayer, StreamLayer, and TextSymbol  The supported font families are based on hosted fonts files in `.pbf` format. By default, the fonts available are mostly the same ones used by the Esri Vector Basemaps. These fonts are available via `https://static.arcgis.com/fonts`. The URL can be configured to point to your own font resources by setting the [esriConfig.fontsUrl](https://developers.arcgis.com/javascript/latest/api-reference/esri-config.html#fontsUrl) property. If an app uses a font that is not installed, the Font class implements a fallback mechanism that will use the default font family value, which is `sans-serif`. This uses the `Arial Unicode MS` font file.  > A preview of the fonts listed in the following table are available in the [Labeling](https://developers.arcgis.com/javascript/latest/labeling/) overview page.  List of fonts currently supported in a 2D MapView:  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Font.html#family">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name = "style">
    ///     The text style.
    ///     default normal
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Font.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name = "weight">
    ///     The text weight.
    ///     default normal
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Font.html#weight">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name = "decoration">
    ///     The text decoration.
    ///     default none
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Font.html#decoration">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public MapFont(Dimension? size = null, string? family = null, MapFontStyle? style = null, FontWeight? weight = null, TextDecoration? decoration = null)
    {
#pragma warning disable BL0005
        Size = size;
        Family = family;
        Style = style;
        Weight = weight;
        Decoration = decoration;
#pragma warning restore BL0005
    }

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
        return new MapFontSerializationRecord(Size?.Points, Family, Style?.ToString(), Weight?.ToString(), Decoration?.ToString());
    }
}

[ProtoContract]
internal record MapFontSerializationRecord
{
    public MapFontSerializationRecord()
    {
    }

    public MapFontSerializationRecord(double? Size, string? Family, string? FontStyle, string? Weight, string? decoration)
    {
        this.Size = Size;
        this.Family = Family;
        this.FontStyle = FontStyle;
        this.Weight = Weight;
        this.Decoration = decoration;
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

    public MapFont FromSerializationRecord()
    {
        return new MapFont(Size, Family, FontStyle is null ? null : Enum.Parse<MapFontStyle>(FontStyle), Weight is null ? null : Enum.Parse<FontWeight>(Weight), Decoration is null ? null : Enum.Parse<TextDecoration>(Decoration));
    }
}