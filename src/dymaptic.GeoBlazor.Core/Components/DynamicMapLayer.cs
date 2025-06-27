namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A dynamic map layer refers to a layer published in a map service that has dynamic layers enabled. This layer type may be used to create multiple sublayers that point to the same service layer, but are assigned different definition expressions, renderers, and other properties.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#DynamicMapLayer">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class DynamicMapLayer : DynamicLayer
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public DynamicMapLayer()
    {
    }

    /// <summary>
    ///     Creates a new DynamicMapLayer in code with parameters.
    /// </summary>
    /// <param name="mapLayerId">
    ///     The id of the service sublayer.
    /// </param>
    /// <param name="gdbVersion">
    ///     An optional property for specifying the GDB version.
    /// </param>
    public DynamicMapLayer(int mapLayerId, string? gdbVersion = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.

        MapLayerId = mapLayerId;
        GdbVersion = gdbVersion;
#pragma warning restore BL0005 // Set parameter or member default value.

    }

    /// <inheritdoc/>
    public override string Type => "map-layer";

    /// <summary>
    ///     The id of the service sublayer.
    /// </summary>
    [Parameter]
    [EditorRequired]
    [RequiredProperty]
    public int MapLayerId { get; set; }

    /// <summary>
    ///     An optional property for specifying the GDB version.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GdbVersion { get; set; }
}


