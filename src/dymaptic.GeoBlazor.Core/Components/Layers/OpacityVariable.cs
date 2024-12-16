using dymaptic.GeoBlazor.Core.Enums;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The opacity visual variable defines the opacity of each feature's symbol based on a numeric field value or number returned from an expression. You must specify stops to construct the opacity ramp.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-OpacityVariable.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class OpacityVariable: VisualVariable
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    public OpacityVariable()
    {
    }

    /// <summary>
    ///     Constructs a new OpacityVariable in code with parameters
    /// </summary>
    /// <param name="field">
    ///     The name of the numeric attribute field that contains the data values used to determine the opacity of each feature.
    /// </param>
    /// <param name="normalizationField">
    ///     The name of the numeric attribute field by which to normalize the data. If this field is used, then the values in stops should be normalized as percentages or ratios.
    /// </param>
    /// <param name="stops">
    ///     An array of objects that defines the opacity to apply to features in a layer in a sequence of stops. You must specify 2 - 8 stops. In most cases, no more than five are needed. Features with data values that fall between the given stops will be assigned opacity values linearly interpolated along the ramp in relation to the stop values. The stops must be listed in ascending order based on the value of the value property in each stop.
    /// </param>
    public OpacityVariable(string field, string? normalizationField = null,
        IReadOnlyList<OpacityStop>? stops = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        NormalizationField = normalizationField;
        Field = field;
        Stops = stops;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    public override VisualVariableType VariableType => VisualVariableType.Opacity;
    
    /// <summary>
    ///     Name of the numeric attribute field by which to normalize the data. If this field is used, then the values in stops should be normalized as percentages or ratios.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NormalizationField { get; set; }
    
    /// <summary>
    ///     An array of objects that defines the opacity to apply to features in a layer in a sequence of stops. You must specify 2 - 8 stops. In most cases, no more than five are needed. Features with data values that fall between the given stops will be assigned opacity values linearly interpolated along the ramp in relation to the stop values. The stops must be listed in ascending order based on the value of the value property in each stop.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<OpacityStop>? Stops
    {
        get => _stops;
        set
        {
            if (value is not null)
            {
                _stops = new List<OpacityStop>(value);
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
            case OpacityStop stop:
                _stops ??= new List<OpacityStop>();
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
            case OpacityStop stop:
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
            foreach (OpacityStop stop in _stops)
            {
                stop.ValidateRequiredChildren();
            }
        }
    }

    private List<OpacityStop>? _stops;
}

/// <summary>
///     Defines a opacity stop used for creating a continuous opacity visualization in a opacity visual variable.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-support-OpacityStop.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class OpacityStop : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    public OpacityStop()
    {
    }
    
    /// <summary>
    ///     Constructs a new OpacityStop in code with parameters
    /// </summary>
    /// <param name="value">
    ///     Specifies the data value to map to the given opacity.
    /// </param>
    /// <param name="opacity">
    ///     The opacity value in points (between 0.0 and 1.0) used to render features with the given value.
    /// </param>
    /// <param name="label">
    ///     A string value used to label the stop in the Legend.
    /// </param>
    public OpacityStop(double value, double opacity, string? label = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Value = value;
        Opacity = opacity;
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
    ///     The opacity value in points (between 0.0 and 1.0) used to render features with the given value.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Opacity { get; set; }
    
    /// <summary>
    ///     Specifies the data value to map to the given opacity.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value {get; set;}
}