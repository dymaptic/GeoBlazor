namespace dymaptic.GeoBlazor.Core.Components;

public partial class RotationVariable : VisualVariable
{


    /// <inheritdoc/>
    public override VisualVariableType Type => VisualVariableType.Rotation;


    /// <summary>
    ///     Defines the origin and direction of rotation depending on how the angle of rotation was measured.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RotationType? RotationType { get; set; }
}