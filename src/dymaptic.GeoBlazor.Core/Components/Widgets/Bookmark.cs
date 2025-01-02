namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
/// A bookmark is a saved map extent that allows end users to quickly navigate
/// to a particular area of interest using the Bookmarks widget.
/// They are usually defined part of the WebMap.
/// </summary>
public class Bookmark : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Blazor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public Bookmark()
    {
    }
    
    /// <summary>
    ///     Constructor for building in C#.
    /// </summary>
    /// <param name="name">
    ///     The name of the bookmark.
    /// </param>
    /// <param name="timeExtent">
    ///     The extent of the specified bookmark.
    /// </param>
    /// <param name="thumbnail">
    ///     The URL for a thumbnail image.
    /// </param>
    /// <param name="viewpoint">
    ///     The viewpoint of the bookmark item. Defines the rotation, scale, and target geometry of the bookmark.
    /// </param>
    public Bookmark(string? name = null, TimeExtent? timeExtent = null, string? thumbnail = null, Viewpoint? viewpoint = null)
    {
#pragma warning disable BL0005
        Name = name;
        TimeExtent = timeExtent;
        Thumbnail = thumbnail;
        Viewpoint = viewpoint;
#pragma warning restore BL0005
    }
    
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

    /// <summary>
    /// The URL for a thumbnail image.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Thumbnail { get; set; }

    /// <summary>
    /// The viewpoint of the bookmark item. Defines the rotation, scale, and target geometry of the bookmark.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Viewpoint? Viewpoint { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Viewpoint viewpoint:
                Viewpoint = viewpoint;
                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Viewpoint _:
                Viewpoint = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }
}
