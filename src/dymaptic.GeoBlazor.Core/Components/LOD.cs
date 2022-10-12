using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A TileLayer has a number of LODs (Levels of Detail). Each LOD corresponds to a map at a given scale or resolution. LOD has no constructor.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LOD.html">ArcGIS JS API</a>
/// </summary>
public class LOD : MapComponent
{
    /// <summary>
    ///     ID for each level.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Level { get; set; }
    
    /// <summary>
    ///     String to be used when constructing a URL to access a tile from this LOD.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LevelValue { get; set; }
    
    /// <summary>
    ///     Resolution in map units of each pixel in a tile for each level.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Resolution { get; set; }
    
    /// <summary>
    ///     Scale for each level.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Scale { get; set; }
}