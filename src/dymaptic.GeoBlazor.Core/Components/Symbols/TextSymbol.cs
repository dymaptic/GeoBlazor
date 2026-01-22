namespace dymaptic.GeoBlazor.Core.Components.Symbols;

[ProtobufSerializable]
public partial class TextSymbol : Symbol
{
    /// <inheritdoc />
    public override SymbolType Type => SymbolType.Text;
    
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
    /// <remarks>
    ///     Known Limitations
    ///         - Sub-pixel halo (i.e. fractional size such as 1.25px) renders inconsistently in various browsers.
    ///         - Halo size should not be 1/4 larger than the text size. For example, if your text size is 12, the halo size should not be larger than 3.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? HaloSize { get; set; }
    
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
    public Dimension? LineWidth { get; set; }
    
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
    public Dimension? Xoffset { get; set; }
    
    /// <summary>
    ///     The offset on the y-axis in points. This value is a string expressing size in points or pixels (e.g. "12px", "12pt"), which defaults to points.
    /// </summary>
    /// <remarks>
    /// This property is currently not supported in 3D SceneViews.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Yoffset { get; set; }

    /// <inheritdoc />
    public override SymbolSerializationRecord ToProtobuf()
    {
        return new SymbolSerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(), Color?.ToProtobuf())
        {
            Text = Text, 
            HaloColor = HaloColor?.ToProtobuf(), 
            HaloSize = HaloSize?.Points,
            Font = Font?.ToProtobuf(),
            Angle = Angle,
            BackgroundColor = BackgroundColor?.ToProtobuf(),
            BorderLineSize = BorderLineSize,
            BorderLineColor = BorderLineColor?.ToProtobuf(),
            HorizontalAlignment = HorizontalAlignment?.ToString().ToKebabCase(),
            Kerning = Kerning,
            LineHeight = LineHeight,
            LineWidth = LineWidth?.Points,
            Rotated = Rotated,
            VerticalAlignment = VerticalAlignment?.ToString().ToKebabCase(),
            Xoffset = Xoffset?.Points,
            Yoffset = Yoffset?.Points
        };
    }
}