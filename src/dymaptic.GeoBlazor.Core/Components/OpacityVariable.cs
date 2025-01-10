namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The opacity visual variable defines the opacity of each feature's symbol based on a numeric field value or number returned from an expression. You must specify stops to construct the opacity ramp.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-OpacityVariable.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class OpacityVariable: VisualVariable
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
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
    public override VisualVariableType Type => VisualVariableType.Opacity;
    
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
    public IReadOnlyList<OpacityStop>? Stops { get; set; }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case OpacityStop stop:
                Stops ??= new List<OpacityStop>();
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
            case OpacityStop stop:
                Stops = Stops?.Except([stop]).ToList();

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();

        if (Stops is not null)
        {
            foreach (OpacityStop stop in Stops)
            {
                stop.ValidateRequiredChildren();
            }
        }
    }
}