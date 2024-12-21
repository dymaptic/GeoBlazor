namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The rotation visual variable defines how features rendered with marker symbols or text symbols in a MapView are
///     rotated. The rotation value is determined by mapping the values to data in a field, or by other arithmetic means
///     with an Arcade expression.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-RotationVariable.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class RotationVariable : VisualVariable
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    public RotationVariable()
    {
    }
    
    /// <summary>
    ///     Constructs a new RotationVariable in code with parameters
    /// </summary>
    /// <param name="field">
    ///     The name of the numeric attribute field that contains the data values used to determine the rotation of each feature.
    /// </param>
    /// <param name="axis">
    ///     Only applicable when working in a SceneView.
    /// </param>
    /// <param name="rotationType">
    ///     Defines the origin and direction of rotation depending on how the angle of rotation was measured.
    /// </param>
    public RotationVariable(string field, string? axis = null,
        RotationType? rotationType = null)
    {
#pragma warning disable BL0005
        Axis = axis;
        Field = field;
        RotationType = rotationType;
#pragma warning restore BL0005
    }
    
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override VisualVariableType VariableType => VisualVariableType.Rotation;

    /// <summary>
    ///     Only applicable when working in a SceneView.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Axis { get; set; }

    /// <summary>
    ///     Defines the origin and direction of rotation depending on how the angle of rotation was measured.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RotationType? RotationType { get; set; }
}