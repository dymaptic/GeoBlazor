namespace dymaptic.GeoBlazor.Pro.Components;

public partial class SnappingControlsElements: MapComponent
{
    /// <summary>
    ///     Indicates whether to display the snapping controls' header. Default value is false.
    /// </summary>
    [Parameter]
    public bool? Header { get; set; }
    
    /// <summary>
    ///     Indicates whether to display the snapping controls' toggle to entirely enable/disable snapping. Default value is true.
    /// </summary>
    [Parameter]
    public bool EnabledToggle { get; set; }
    
    /// <summary>
    ///     Indicates whether to display the snapping controls' toggle to enable/disable Geometry guides. Default value is true.
    /// </summary>
    [Parameter]
    public bool? SelfEnabledToggle { get; set; }
    
    /// <summary>
    ///     Indicates whether to display the snapping controls' toggle to enable/disable Feature to feature snapping. Default is true.
    /// </summary>
    [Parameter]
    public bool? FeatureEnabledToggle { get; set; }
    
    /// <summary>
    ///     Indicates whether to display snapping controls' Snapping layers. Default value is true.
    /// </summary>
    [Parameter]
    public bool? LayerList { get; set; }
}