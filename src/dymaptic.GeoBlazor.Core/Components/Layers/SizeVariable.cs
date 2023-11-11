using dymaptic.GeoBlazor.Core.Extensions;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The size visual variable defines the size of individual features in a layer based on a numeric (often thematic)
///     value.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SizeVariable : VisualVariable
{
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
    [JsonConverter(typeof(NumberToStringConverter))]
    public string? MinSize { get; set; }

    /// <summary>
    ///     The size used to render a feature containing the maximum data value.
    ///     When setting a number, sizes are expressed in points for all 2D symbols and 3D flat symbol layers; size is expressed in meters for all 3D volumetric symbols.
    ///     String values are only supported for 2D symbols and 3D flat symbol layers. Strings may specify size in either points or pixels (e.g. minSize: "16pt", minSize: "12px").
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(NumberToStringConverter))]
    public string? MaxSize { get; set; }
    
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
    public IReadOnlyCollection<SizeStop>? Stops
    {
        get => _stops;
        set
        {
            if (value is not null)
            {
                _stops = new HashSet<SizeStop>(value);
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
                _stops ??= new HashSet<SizeStop>();
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

    private HashSet<SizeStop>? _stops;
}

/// <summary>
///     Defines a size stop used for creating a continuous size visualization in a size visual variable.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-support-SizeStop.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SizeStop : MapComponent
{
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
    public string? Size { get; set; }
    
    /// <summary>
    ///     Specifies the data value to map to the given size.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value {get; set;}
}

/// <summary>
///     Only applicable when working in a SceneView. Defines the axis the size visual variable should be applied to when rendering features with an ObjectSymbol3DLayer. See the local scene sample for an example of this.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<VisualAxis>))]
public enum VisualAxis
{
#pragma warning disable CS1591
    Width,
    Depth,
    Height,
    WidthAndDepth,
    All
#pragma warning restore CS1591
}

/// <summary>
///     Specifies how to apply the data value when mapping real-world sizes.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<VisualValueRepresentation>))]
public enum VisualValueRepresentation
{
#pragma warning disable CS1591
    Radius,
    Diameter,
    Area,
    Width,
    Distance
#pragma warning restore CS1591
}

/// <summary>
///     Specifies how to apply the data value when mapping real-world sizes.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<VisualValueUnit>))]
public enum VisualValueUnit
{
#pragma warning disable CS1591
    Unknown,
    Inches,
    Feet,
    Yards,
    Miles,
    NauticalMiles,
    Millimeters,
    Centimeters,
    Decimeters,
    Meters,
    Kilometers,
    DecimalDegrees
#pragma warning restore CS1591
}