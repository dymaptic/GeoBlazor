namespace dymaptic.GeoBlazor.Core.Components;

public partial class LabelExpressionInfo : MapComponent
{
    /// <summary>
    ///     An Arcade expression following the specification defined by the Arcade Labeling Profile. Expressions in labels may reference field values using the $feature global variable and must return a string.
    /// </summary>
    [Parameter]
    [EditorRequired]
    [RequiredProperty]
    public string Expression { get; set; } = null!;
}