using dymaptic.GeoBlazor.Core.Extensions;
using dymaptic.GeoBlazor.Core.Objects;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     Text symbols are used to define the graphic for displaying labels on a FeatureLayer, CSVLayer, Sublayer, and
///     StreamLayer in a 2D MapView. Text symbols can also be used to define the symbol property of Graphic if the geometry
///     type is Point or Multipoint. With this class, you may alter the color, font, halo, and other properties of the
///     label graphic.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-TextSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class TextSymbol : Symbol
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public TextSymbol()
    {
    }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="text">
    ///     The text string to display in the view.
    /// </param>
    /// <param name="color">
    ///     The color of the symbol.
    /// </param>
    /// <param name="haloColor">
    ///     The color of the text symbol's halo.
    /// </param>
    /// <param name="haloSize">
    ///     The size in points of the text symbol's halo.
    /// </param>
    /// <param name="font">
    ///     The <see cref="MapFont" /> used to style the text.
    /// </param>
    /// <param name="angle">
    ///     The angle of the text. 0 is horizontal and the angle moves clockwise.
    /// </param>
    /// <param name="backgroundColor">
    ///     The background color of the label's bounding box.
    /// </param>
    /// <param name="borderLineColor">
    ///     The border color of the label's bounding box.
    /// </param>
    /// <param name="borderLineSize">
    ///     The border size or width of the label's bounding box.
    /// </param>
    /// <param name="horizontalAlignment">
    ///     Adjusts the horizontal alignment of the text in multi-lines. Default value is Center.
    /// </param>
    /// <param name="kerning">
    ///     Determines whether to adjust the spacing between characters in the text string. Default value is true.
    /// </param>
    /// <param name="lineHeight">
    ///     The height of the space between each line of text. Only applies to multiline text.
    /// </param>
    /// <param name="lineWidth">
    ///     The maximum length in points for each line of text. This value is a string expressing size in points or pixels (e.g.
    /// </param>
    /// <param name="rotated">
    ///     Determines whether every character in the text string is rotated. Default value is false.
    /// </param>
    /// <param name="verticalAlignment">
    ///     Adjusts the vertical alignment of the text. Default value is Baseline.
    /// </param>
    /// <param name="xOffset">
    ///     The offset on the x-axis in points. This value is a string expressing size in points or pixels (e.g. "12px", "12pt"),
    /// </param>
    /// <param name="yOffset">
    ///     The offset on the y-axis in points. This value is a string expressing size in points or pixels (e.g. "12px", "12pt"),
    /// </param>
    public TextSymbol(string text, MapColor? color = null, MapColor? haloColor = null, int? haloSize = null,
        MapFont? font = null, double? angle = null, MapColor? backgroundColor = null, MapColor? borderLineColor = null,
        double? borderLineSize = null, HorizontalAlignment? horizontalAlignment = null, bool? kerning = null,
        double? lineHeight = null, string? lineWidth = null, bool? rotated = null, 
        VerticalAlignment? verticalAlignment = null, string? xOffset = null, string? yOffset = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Text = text;
        Color = color;
        HaloColor = haloColor;
        HaloSize = haloSize;
        Font = font;
        Angle = angle;
        BackgroundColor = backgroundColor;
        BorderLineColor = borderLineColor;
        BorderLineSize = borderLineSize;
        HorizontalAlignment = horizontalAlignment;
        Kerning = kerning;
        LineHeight = lineHeight;
        LineWidth = lineWidth;
        Rotated = rotated;
        VerticalAlignment = verticalAlignment;
        XOffset = xOffset;
        YOffset = yOffset;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    public override string Type => "text";
    
    /// <summary>
    ///     The angle of the text. 0 is horizontal and the angle moves clockwise.
    /// </summary>
    /// <remarks>
    ///     This property is currently not supported in 3D SceneViews.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Angle { get; set; }
    
    /// <summary>
    ///     The background color of the label's bounding box.
    /// </summary>
    /// <remarks>
    ///     This property is currently not supported when labelling a FeatureLayer polyline with a "curved" labelPosition.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? BackgroundColor { get; set; }
    
    /// <summary>
    ///     The border color of the label's bounding box.
    /// </summary>
    /// <remarks>
    ///     This property is currently not supported when labelling a FeatureLayer polyline with a "curved" labelPosition.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? BorderLineColor { get; set; }
    
    /// <summary>
    ///     The border size or width of the label's bounding box.
    /// </summary>
    /// <remarks>
    ///     This property is currently not supported when labelling a FeatureLayer polyline with a "curved" labelPosition.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? BorderLineSize { get; set; }

    /// <summary>
    ///     The color of the text symbol's halo.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? HaloColor { get; set; }

    /// <summary>
    ///     The size in points of the text symbol's halo.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? HaloSize { get; set; }
    
    /// <summary>
    ///     Adjusts the horizontal alignment of the text in multi-lines. Default value is Center.
    /// </summary>
    /// <remarks>
    ///     This property only applies when TextSymbol is not used for labeling purposes. The horizontalAlignment for labels is inferred from the labelPlacement value.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HorizontalAlignment? HorizontalAlignment { get; set; }
    
    /// <summary>
    ///     Determines whether to adjust the spacing between characters in the text string. Default value is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Kerning { get; set; }
    
    /// <summary>
    ///     The height of the space between each line of text. Only applies to multiline text.
    ///     This property can be considered as a multiplier of the default value of 1.0 (e.g. a value of 2.0 will be two times the height of the default height). The range of possible values is: 0.1 - 4.0. If a value of 0 is specified, the default value of 1.0 will be used.
    ///     Default Value: 1.0
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? LineHeight { get; set; }
    
    /// <summary>
    ///     The maximum length in points for each line of text. This value is a string expressing size in points or pixels (e.g. "12px", "12pt"), which defaults to points.
    ///     The default value is 192 points. The range of possible values is: 32px - 512px.
    ///     If text extends farther than the lineWidth value, then the line will break at the whitespace before the text that extends past the limit if possible, and a new line will be created.
    /// </summary>
    /// <remarks>
    ///     Known Limitations:
    ///     - This property is currently not supported in 3D SceneViews.
    ///     - The default value is subject to change in future releases.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(NumberToStringConverter))]
    public string? LineWidth { get; set; }
    
    /// <summary>
    ///     Determines whether every character in the text string is rotated. Default value is false.
    /// </summary>
    /// <remarks>
    ///     This property is currently not supported in 3D SceneViews.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Rotated { get; set; }

    /// <summary>
    ///     The text string to display in the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }
    
    /// <summary>
    ///     Adjusts the vertical alignment of the text. Default value is Baseline.
    /// </summary>
    /// <remarks>
    ///     This property only applies when TextSymbol is not used for labeling purposes. The verticalAlignment for labels is inferred from the labelPlacement value.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VerticalAlignment? VerticalAlignment { get; set; }
    
    /// <summary>
    ///     The offset on the x-axis in points. This value is a string expressing size in points or pixels (e.g. "12px", "12pt"), which defaults to points.
    /// </summary>
    /// <remarks>
    /// This property is currently not supported in 3D SceneViews.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(NumberToStringConverter))]
    public string? XOffset { get; set; }
    
    /// <summary>
    ///     The offset on the y-axis in points. This value is a string expressing size in points or pixels (e.g. "12px", "12pt"), which defaults to points.
    /// </summary>
    /// <remarks>
    /// This property is currently not supported in 3D SceneViews.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(NumberToStringConverter))]
    public string? YOffset { get; set; }

    /// <summary>
    ///     The <see cref="MapFont" /> used to style the text.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapFont? Font { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case MapFont mapFont:
                if (!mapFont.Equals(Font))
                {
                    Font = mapFont;
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case MapFont _:
                Font = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Font?.ValidateRequiredChildren();
    }

    internal override SymbolSerializationRecord ToSerializationRecord()
    {
        return new SymbolSerializationRecord(Type, Color)
        {
            Text = Text, 
            HaloColor = HaloColor, 
            HaloSize = HaloSize is null ? null : (int)HaloSize.Value,
            MapFont = Font,
            Angle = Angle,
            BackgroundColor = BackgroundColor,
            BorderLineSize = BorderLineSize,
            BorderLineColor = BorderLineColor,
            HorizontalAlignment = HorizontalAlignment?.ToString(),
            Kerning = Kerning,
            LineHeight = LineHeight,
            LineWidth = LineWidth,
            Rotated = Rotated,
            VerticalAlignment = VerticalAlignment?.ToString()
        };
    }
}

/// <summary>
///     The horizontal alignment for a text symbol's text.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<HorizontalAlignment>))]
public enum HorizontalAlignment
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Left,
    Right,
    Center
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

/// <summary>
///     The vertical alignment for a text symbol's text.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<VerticalAlignment>))]
public enum VerticalAlignment
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Baseline,
    Top,
    Middle,
    Bottom
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}