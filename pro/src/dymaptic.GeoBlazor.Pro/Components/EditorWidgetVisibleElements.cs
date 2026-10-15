namespace dymaptic.GeoBlazor.Pro.Components;

public partial class EditorWidgetVisibleElements : MapComponent
{
    /// <summary>
    ///     Indicates whether to display tooltips while sketching. Default value is true.
    /// </summary>
    [Parameter]
    public bool? SketchTooltipControls { get; set; }

    /// <summary>
    ///     Indicates whether snapping controls will be displayed. Default value is true.
    /// </summary>
    [Parameter]
    public bool? SnappingControls { get; set; }
    /// <summary>
    ///     The elements contained within the snapping controls.
    /// </summary>
    public SnappingControlsElements? SnappingControlsElement { get; set; }

    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SnappingControlsElements element:
                SnappingControlsElement = element;
                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SnappingControlsElements _:
                SnappingControlsElement = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }

}

