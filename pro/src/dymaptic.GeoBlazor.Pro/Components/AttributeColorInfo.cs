namespace dymaptic.GeoBlazor.Pro.Components;

public partial class AttributeColorInfo : MapComponent
{
    /// <summary>
    ///     The color used to render dots representing the given field in a DotDensityRenderer or the color used to represent a pie chart slice in a PieChartRenderer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? Color { get; set; }

    /// <summary>
    ///     The name of the numeric attribute field represented by the given color.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Field { get; set; }

    /// <summary>
    ///     The label used to describe the field or attribute in the Legend widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

    /// <summary>
    ///     An Arcade expression following the specification defined by the Arcade Visualization Profile. Expressions in DotDensityRenderer may reference field values using the $feature profile variable and must return a number equal to the number of units represented by each dot. Expressions in PieChartRenderer must return a number representing the size of the pie chart slice.
    ///     This takes precedence over field. Therefore, this property is typically used as an alternative to field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ValueExpression { get; set; }

    /// <summary>
    ///     The title identifying and describing the associated Arcade expression as defined in the valueExpression property. This is displayed as the label of the attribute in the Legend in the absence of one provided in the label property.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ValueExpressionTitle { get; set; }
}


