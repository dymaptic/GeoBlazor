namespace dymaptic.GeoBlazor.Core.Components;

public partial class SnappingOptions : MapComponent
{
    /// <summary>
    ///     Global configuration to turn snapping on or off. Note that snapping is turned off by default.
    ///     Default Value:false
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>
    ///     Snapping distance for snapping in pixels.
    ///     Default Value:5
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Distance { get; set; }

    /// <summary>
    ///     Global configuration option to turn feature snapping on or off.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? FeatureEnabled { get; set; }

    /// <summary>
    ///     Global configuration option to turn self snapping (within one feature while either drawing or reshaping) on or off.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SelfEnabled { get; set; }

}
