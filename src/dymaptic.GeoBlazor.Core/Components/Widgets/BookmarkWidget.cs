using dymaptic.GeoBlazor.Core.Components.Views;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;
/// <summary>
/// The bookmarks widget displays a collection of bookmarks defined in the map or manually by the user. 
/// The Bookmarks widget allows end users to quickly navigate to a particular area of interest. 
/// It displays a list of bookmarks, which are typically defined inside the WebMap.
/// <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks.html#properties-summary">
/// </summary>
public class BookmarkWidget : Widget
{
    ///<inheritdoc/>
    [JsonPropertyName("type")]
    public override string WidgetType => "bookmark";

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Thumbnail { get; set; }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? IconClass { get; set; }

    [Parameter]
    public new MapView? View { get; set; }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

    public DotNetObjectReference<BookmarkWidget> BookmarkWidgetObjectReference => DotNetObjectReference.Create(this);

    public bool HasCustomBookmarkHandler => OnBookmarkCreatedHandler is not null;
}

