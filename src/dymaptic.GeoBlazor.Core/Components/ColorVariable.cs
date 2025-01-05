namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The color visual variable is used to visualize features along a continuous color ramp based on the values of a numeric attribute field or an expression. The color ramp is defined along a sequence of stops, where color values are mapped to data values. Data values that fall between two stops are assigned a color that is linearly interpolated based on the value's position relative to the closest defined stops.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-ColorVariable.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ColorVariable : VisualVariable
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ColorVariable()
    {
    }
    
    /// <summary>
    ///     Constructs a new ColorVariable in code with parameters
    /// </summary>
    /// <param name="field">
    ///     The name of the numeric attribute field that contains the data values used to determine the color/opacity/size/rotation of each feature.
    /// </param>
    /// <param name="normalizationField">
    ///     The name of the numeric attribute field by which to normalize the data. If this field is used, then the values in stops should be normalized as percentages or ratios.
    /// </param>
    /// <param name="stops">
    ///     An array of sequential objects, or stops, that defines a continuous color ramp. You must specify 2 - 8 stops. In most cases, no more than five are needed. Features with values that fall between the given stops will be assigned colors linearly interpolated along the ramp in relation to the nearest stop values. The stops must be listed in ascending order based on the value of the value property in each stop.
    /// </param>
    public ColorVariable(string field, string? normalizationField = null,
        IReadOnlyList<ColorStop>? stops = null)
    {
#pragma warning disable BL0005
        NormalizationField = normalizationField;
        Field = field;
        Stops = stops;
#pragma warning restore BL0005
    }
    
    /// <inheritdoc />
    public override VisualVariableType Type => VisualVariableType.Color;

    /// <summary>
    ///     Name of the numeric attribute field by which to normalize the data. If this field is used, then the values in stops should be normalized as percentages or ratios.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NormalizationField { get; set; }

    /// <summary>
    ///     An array of sequential objects, or stops, that defines a continuous color ramp. You must specify 2 - 8 stops. In most cases, no more than five are needed. Features with values that fall between the given stops will be assigned colors linearly interpolated along the ramp in relation to the nearest stop values. The stops must be listed in ascending order based on the value of the value property in each stop.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<ColorStop>? Stops
    {
        get => _stops;
        set
        {
            if (value is not null)
            {
                _stops = new List<ColorStop>(value);
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
            case ColorStop stop:
                _stops ??= new List<ColorStop>();
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
            case ColorStop stop:
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
            foreach (ColorStop stop in _stops)
            {
                stop.ValidateRequiredChildren();
            }
        }
    }
    
    private List<ColorStop>? _stops;
}

/// <summary>
///     Defines a color stop used for creating a continuous color visualization in a color visual variable.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-support-ColorStop.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ColorStop: MapComponent
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ColorStop()
    {
    }
    
    /// <summary>
    ///     Constructs a new ColorStop in code with parameters
    /// </summary>
    /// <param name="value">
    ///     Specifies the data value to map to the given color.
    /// </param>
    /// <param name="color">
    ///     The Color used to render features with the given value.
    /// </param>
    /// <param name="label">
    ///     A string value used to label the stop along the color ramp in the Legend.
    /// </param>
    public ColorStop(double value, MapColor color, string? label = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Value = value;
        Color = color;
        Label = label;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     The Color used to render features with the given value.
    /// </summary>
    [Parameter]
    [RequiredProperty]
    public MapColor? Color { get; set; }
    
    /// <summary>
    ///     A string value used to label the stop along the color ramp in the Legend.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
    
    /// <summary>
    ///     Specifies the data value to map to the given color.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value { get; set; }
}