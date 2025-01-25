namespace dymaptic.GeoBlazor.Core.Components;

public partial class LOD : MapComponent
{


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