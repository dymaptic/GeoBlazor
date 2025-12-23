namespace dymaptic.GeoBlazor.Core.Components;

public partial class DynamicMapLayer : DynamicLayer
{


    /// <inheritdoc/>
    public override string Type => "map-layer";


    /// <summary>
    ///     An optional property for specifying the GDB version.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GdbVersion { get; set; }
}


