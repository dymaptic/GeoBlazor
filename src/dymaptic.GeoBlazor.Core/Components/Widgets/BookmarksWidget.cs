using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Bookmarks widget allows end users to quickly navigate to a particular area of interest. It displays a list of bookmarks, which are typically defined inside the WebMap.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class BookmarksWidget : Widget
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override string WidgetType => "bookmarks";

    /// <summary>
    ///     When true, the widget is visually withdrawn and cannot be interacted with.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Disabled { get; set; }


    /// <summary>
    ///    Indicates whether the bookmarks are able to be edited.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? EditingEnabled { get; set; }

    /// <summary>
    /// Indicates the heading level to use for the message "No bookmarks" when no bookmarks are available in this widget.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? HeadingLevel { get; set; }


    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Bookmark> Bookmarks { get; set; } = new();

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Bookmark bookmark:
                if (!Bookmarks.Contains(bookmark)) Bookmarks.Add(bookmark);
                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Bookmark bookmark:
                if (Bookmarks.Contains(bookmark)) Bookmarks.Remove(bookmark);
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }

    }
}

public class Bookmark : MapComponent
{
    /// <summary>
    ///    ///     The extent of the specified bookmark.
    ///    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeExtent? TimeExtent { get; set; }
    ///
    ///    /// <summary>
    ///    ///     The name of the bookmark.
    ///    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; set; }

    /// <summary>
    /// The URL for a thumbnail image.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Thumbnail { get; set; }

    /// <summary>
    /// The URL for a thumbnail image.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ViewPoint? ViewPoint { get; set; }

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ViewPoint viewPoint:
                ViewPoint = viewPoint;
                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ViewPoint viewPoint:
                ViewPoint = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }

    }

}

public class ViewPoint : MapComponent
{
    ///public Camera Camera { get; set; }

    /// <summary>
    /// The rotation of due north in relation to the top of the view in degrees.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Rotation { get; set; }

    /// <summary>
    ///  The scale of the viewpoint.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Scale { get; set; }

    /// <summary>
    /// The target geometry framed by the viewpoint.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? TargetGeometry { get; set; }

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Geometry geometry:
                TargetGeometry = geometry;
                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Geometry geometry:
                TargetGeometry = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }

    }

}