using dymaptic.GeoBlazor.Core.Components.Views;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;

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
    public string? Name { get; set; }

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
    public Viewpoint? Viewpoint { get; set; }


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

    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Viewpoint viewpoint:
                Viewpoint = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }
}



