namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///     LayerFloorInfo contains properties that allow a layer to be floor-aware. These properties are used to filter the levels, or floors, of a facility that are displayed. The FloorFilter widget currently supports FeatureLayers, SceneLayers and MapImageLayers (map services).
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LayerFloorInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class LayerFloorInfo : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public LayerFloorInfo()
    {
    }

    /// <summary>
    ///     Creates a new LayerFloorInfo in code with parameters.
    /// </summary>
    /// <param name="floorField">
    ///     The field name derived from a floor-aware layer and used to filter features by floor level.
    /// </param>
    public LayerFloorInfo(string floorField)
    {
#pragma warning disable BL0005 // Set parameter or member default value.

        FloorField = floorField;
#pragma warning restore BL0005 // Set parameter or member default value.

    }

    /// <summary>
    ///     The field name derived from a floor-aware layer and used to filter features by floor level.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FloorField { get; set; }
}