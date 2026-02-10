namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(SizeVariableConverter))]
public partial class SizeVariable : VisualVariable, IMapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public SizeVariable()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="field">
    ///     The name of the numeric attribute field that contains the data
    ///     values used to determine the color/opacity/size/rotation of each feature.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-VisualVariable.html#field">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minSize">
    ///     The size used to render a feature containing the minimum data value.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#minSize">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="maxSize">
    ///     The size used to render a feature containing the maximum data value.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#maxSize">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minDataValue">
    ///     The minimum data value used in the size ramp.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#minDataValue">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="maxDataValue">
    ///     The maximum data value used in the size ramp.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#maxDataValue">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="valueRepresentation">
    ///     Specifies how to apply the data value when mapping real-world sizes.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#valueRepresentation">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="valueUnit">
    ///     Indicates the unit of measurement used to interpret the value returned by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#field">field</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#valueExpression">valueExpression</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#valueUnit">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="normalizationField">
    ///     The name of the numeric attribute field used to normalize
    ///     the data in the given <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#field">field</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#normalizationField">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="target">
    ///     This value must be `outline` when scaling polygon outline widths
    ///     based on the view scale.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#target">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="useSymbolValue">
    ///     When setting a size visual variable on a renderer using an
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-ObjectSymbol3DLayer.html">ObjectSymbol3DLayer</a>, this property indicates whether to apply the value
    ///     defined by the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-ObjectSymbol3DLayer.html#height">height</a>,
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-ObjectSymbol3DLayer.html#width">width</a>, or
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-ObjectSymbol3DLayer.html#depth">depth</a> properties to the corresponding <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#axis">axis</a> of
    ///     this visual variable instead of proportionally scaling this axis' value.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#useSymbolValue">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="axis">
    ///     Only applicable when working in a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">SceneView</a>.
    ///     default "all"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#axis">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="valueExpression">
    ///     An <a target="_blank" href="https://developers.arcgis.com/javascript/latest/arcade/">Arcade</a> expression following the specification
    ///     defined by the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/arcade/#visualization">Arcade Visualization Profile</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-VisualVariable.html#valueExpression">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="valueExpressionTitle">
    ///     The title identifying and describing the associated
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/arcade/">Arcade</a> expression as defined in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-VisualVariable.html#valueExpression">valueExpression</a> property.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-VisualVariable.html#valueExpressionTitle">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="legendOptions">
    ///     An object providing options for displaying the visual variable in
    ///     the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/references/map-components/arcgis-legend/">Legend</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-VisualVariable.html#legendOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="stops">
    ///     An array of objects that defines the mapping of data values returned from <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#field">field</a> or
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#valueExpression">valueExpression</a> to icon sizes.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#stops">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public SizeVariable(string? field,
        Dimension? minSize = null,
        Dimension? maxSize = null,
        double? minDataValue = null,
        double? maxDataValue = null,
        VisualValueRepresentation? valueRepresentation = null,
        VisualValueUnit? valueUnit = null,
        string? normalizationField = null,
        string? target = null,
        bool? useSymbolValue = null,
        VisualAxis? axis = null,
        string? valueExpression = null,
        string? valueExpressionTitle = null,
        VisualVariableLegendOptions? legendOptions = null,
        IReadOnlyList<SizeStop>? stops = null)
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
        Stops = stops;
#pragma warning restore BL0005
    }

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
    [CodeGenerationIgnore]
    public Dimension? MinSize { get; set; }

    /// <summary>
    ///     The size used to render a feature containing the maximum data value.
    ///     When setting a number, sizes are expressed in points for all 2D symbols and 3D flat symbol layers; size is expressed in meters for all 3D volumetric symbols.
    ///     String values are only supported for 2D symbols and 3D flat symbol layers. Strings may specify size in either points or pixels (e.g. minSize: "16pt", minSize: "12px").
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public Dimension? MaxSize { get; set; }

    /// <summary>
    ///     The size used to render a feature containing the minimum data value.
    ///     When a SizeVariable is used, the size of features whose data value (defined in field or valueExpression) is greater than or equal to the minDataValue for the given view scale.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public SizeVariable? MinSizeVariable { get; set; }

    /// <summary>
    ///     The size used to render a feature containing the maximum data value.
    ///     When a SizeVariable is used, the size of features whose data value (defined in field or valueExpression) is greater than or equal to the maxDataValue for the given view scale.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public SizeVariable? MaxSizeVariable { get; set; }

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