namespace dymaptic.GeoBlazor.Core.Components;

public partial class Bookmark : MapComponent
{
    /// <summary>
    /// The extent of the specified bookmark.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeExtent? TimeExtent { get; set; }

    /// <summary>
    /// The name of the bookmark.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
}