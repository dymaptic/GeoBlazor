namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The size visual variable defines the size of individual features in a layer based on a numeric (often thematic)
///     value.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SizeVariable : VisualVariable
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public SizeVariable()
    {
    }

    /// <summary>
    ///     Constructs a new SizeVariable in code with parameters
    /// </summary>
    /// <param name="field">
    ///     The name of the numeric attribute field that contains the data values used to determine the size of each feature.
    /// </param>
    /// <param name="minSize">
    ///     The size used to render a feature containing the minimum data value.
    /// </param>
    /// <param name="maxSize">
    ///     The size used to render a feature containing the maximum data value.
    /// </param>
    /// <param name="minDataValue">
    ///     The minimum data value used in the size ramp.
    /// </param>
    /// <param name="maxDataValue">
    ///     The maximum data value used in the size ramp.
    /// </param>
    /// <param name="valueRepresentation">
    ///     Specifies how to apply the data value when mapping real-world sizes.
    /// </param>
    /// <param name="valueUnit">
    ///     Indicates the unit of measurement used to interpret the value returned by field or valueExpression. For 3D volumetric symbols the default is meters. This property should not be used if the data value represents a thematic quantity (e.g. traffic count, census data, etc.).
    /// </param>
    /// <param name="normalizationField">
    ///     The name of the numeric attribute field used to normalize the data in the given field. If this field is used, then the values in maxDataValue and minDataValue or stops should be normalized as percentages or ratios.
    /// </param>
    /// <param name="target">
    ///     This value must be outline when scaling polygon outline widths based on the view scale. If scale-dependent icons are desired, then this property should be ignored.
    /// </param>
    /// <param name="useSymbolValue">
    ///     When setting a size visual variable on a renderer using an ObjectSymbol3DLayer, this property indicates whether to apply the value defined by the height, width, or depth properties to the corresponding axis of this visual variable instead of proportionally scaling this axis' value.
    /// </param>
    /// <param name="axis">
    ///     Only applicable when working in a SceneView. Defines the axis the size visual variable should be applied to when rendering features with an ObjectSymbol3DLayer. See the local scene sample for an example of this.
    /// </param>
    /// <param name="valueExpression">
    ///     An Arcade expression following the specification defined by the Arcade Visualization Profile. Expressions in visual variables may reference field values using the $feature profile variable and must return a number.
    /// </param>
    /// <param name="valueExpressionTitle">
    ///     The title identifying and describing the associated Arcade expression as defined in the valueExpression property. This is displayed as the title of the corresponding visual variable in the Legend in the absence of a provided title in the legendOptions property.
    /// </param>
    /// <param name="legendOptions">
    ///     An object providing options for displaying the visual variable in the Legend.
    /// </param>
    public SizeVariable(string field, Dimension? minSize = null, Dimension? maxSize = null,
        double? minDataValue = null, double? maxDataValue = null,
        VisualValueRepresentation? valueRepresentation = null, VisualValueUnit? valueUnit = null,
        string? normalizationField = null, string? target = null, bool? useSymbolValue = null, VisualAxis? axis = null,
        string? valueExpression = null, string? valueExpressionTitle = null, VisualVariableLegendOptions? legendOptions = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Field = field;
        MinSize = minSize;
        MaxSize = maxSize;
        MinDataValue = minDataValue;
        MaxDataValue = maxDataValue;
        ValueRepresentation = valueRepresentation;
        ValueUnit = valueUnit;
        NormalizationField = normalizationField;
        Target = target;
        UseSymbolValue = useSymbolValue;
        Axis = axis;
        ValueExpression = valueExpression;
        ValueExpressionTitle = valueExpressionTitle;
        LegendOptions = legendOptions;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override VisualVariableType VariableType => VisualVariableType.Size;

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

    /// <summary>
    ///     An array of objects that defines the mapping of data values returned from field or valueExpression to icon sizes. You must specify 2 - 6 stops. The stops must be listed in ascending order based on the value of the value property in each stop.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<SizeStop>? Stops
    {
        get => _stops;
        set
        {
            if (value is not null)
            {
                _stops = new List<SizeStop>(value);
            }
            else
            {
                _stops = null;
            }
        }
    }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SizeStop stop:
                _stops ??= new List<SizeStop>();
                _stops.Add(stop);

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
                _stops?.Remove(stop);

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();

        if (_stops is not null)
        {
            foreach (SizeStop stop in _stops)
            {
                stop.ValidateRequiredChildren();
            }
        }
    }

    private List<SizeStop>? _stops;
}

/// <summary>
///     Defines a size stop used for creating a continuous size visualization in a size visual variable.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-support-SizeStop.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SizeStop : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public SizeStop()
    {
    }

    /// <summary>
    ///     Constructs a new SizeStop in code with parameters
    /// </summary>
    /// <param name="value">
    ///     Specifies the data value to map to the given size.
    /// </param>
    /// <param name="size">
    ///     The size value in points (between 0 and 90) used to render features with the given value. This value may also be autocast from a string in points or pixels.
    /// </param>
    /// <param name="label">
    ///     A string value used to label the stop in the Legend.
    /// </param>
    public SizeStop(double value, Dimension? size = null, string? label = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Value = value;
        Size = size;
        Label = label;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     A string value used to label the stop in the Legend.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
    
    /// <summary>
    ///     The size value in points (between 0 and 90) used to render features with the given value. This value may also be autocast from a string in points or pixels.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Size { get; set; }
    
    /// <summary>
    ///     Specifies the data value to map to the given size.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value {get; set;}
}