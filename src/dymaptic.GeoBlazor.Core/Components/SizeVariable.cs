namespace dymaptic.GeoBlazor.Core.Components;

public partial class SizeVariable : VisualVariable
{


    /// <inheritdoc />
    public override VisualVariableType Type => VisualVariableType.Size;

    /// <summary>
    ///     Only applicable when working in a SceneView. Defines the axis the size visual variable should be applied to when rendering features with an ObjectSymbol3DLayer. See the local scene sample for an example of this.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisualAxis? Axis { get; set; }
    
    /// <summary>
    ///     The minimum data value used in the size ramp.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinDataValue { get; set; }

    /// <summary>
    ///     The maximum data value used in the size ramp.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxDataValue { get; set; }

    /// <summary>
    ///     The size used to render a feature containing the minimum data value.
    ///     When setting a number, sizes are expressed in points for all 2D symbols and 3D flat symbol layers; size is expressed in meters for all 3D volumetric symbols.
    ///     String values are only supported for 2D symbols and 3D flat symbol layers. Strings may specify size in either points or pixels (e.g. minSize: "16pt", minSize: "12px").
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? MinSize { get; set; }

    /// <summary>
    ///     The size used to render a feature containing the maximum data value.
    ///     When setting a number, sizes are expressed in points for all 2D symbols and 3D flat symbol layers; size is expressed in meters for all 3D volumetric symbols.
    ///     String values are only supported for 2D symbols and 3D flat symbol layers. Strings may specify size in either points or pixels (e.g. minSize: "16pt", minSize: "12px").
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? MaxSize { get; set; }
    
    /// <summary>
    ///     The name of the numeric attribute field used to normalize the data in the given field. If this field is used, then the values in maxDataValue and minDataValue or stops should be normalized as percentages or ratios.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NormalizationField { get; set; }
    
    /// <summary>
    ///     This value must be outline when scaling polygon outline widths based on the view scale. If scale-dependent icons are desired, then this property should be ignored.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Target { get; set; }
    
    /// <summary>
    ///     When setting a size visual variable on a renderer using an ObjectSymbol3DLayer, this property indicates whether to apply the value defined by the height, width, or depth properties to the corresponding axis of this visual variable instead of proportionally scaling this axis' value.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? UseSymbolValue { get; set; }
    
    /// <summary>
    ///     Specifies how to apply the data value when mapping real-world sizes.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisualValueRepresentation? ValueRepresentation { get; set; }
    
    /// <summary>
    ///     Indicates the unit of measurement used to interpret the value returned by field or valueExpression. For 3D volumetric symbols the default is meters. This property should not be used if the data value represents a thematic quantity (e.g. traffic count, census data, etc.).
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisualValueUnit? ValueUnit { get; set; }

    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SizeStop stop:
                Stops ??= [];
                Stops = [..Stops, stop];

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
            case SizeStop stop:
                Stops = Stops?.Except([stop]).ToList();

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

}